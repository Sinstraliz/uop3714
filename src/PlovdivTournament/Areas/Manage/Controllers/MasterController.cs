using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Web.Manage.Models;
using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using System.Text;

namespace PlovdivTournament.Web.Manage.Controllers
{
    public class MasterController : Controller
    {
        public ISession Session { get; set; }

        public SecurityManager SecurityManager { get; set; }

        [HttpPost]
        public ActionResult Save(MasterViewModel model)
        {
            var html = Uri.UnescapeDataString(model.PageContent);

            html = html.Replace("contenteditable=\"false\"", "contenteditable=\"true\"");

            var controller = model.Page.Substring(0, model.Page.IndexOf('/'));

            var action = model.Page.Substring(model.Page.IndexOf('/') + 1, model.Page.Length - model.Page.IndexOf('/') - 1);

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == controller && x.Language == model.CurrentLanguage);

            if (content == null)
                content = new Content(controller, model.CurrentLanguage, html);
            else
            {
                content.PageContent = html;

                if (controller == "Info")
                    content.Page = action;
            }

            Session.SaveOrUpdate(content);

            return RedirectToAction(action, controller);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(MasterViewModel model)
        {
            HttpContext.Response.Cookies.Add(new HttpCookie("Language", model.CurrentLanguage));

            var controller = model.Page.Substring(0, model.Page.IndexOf('/'));

            var action = model.Page.Substring(model.Page.IndexOf('/') + 1, model.Page.Length - model.Page.IndexOf('/') - 1);

            return RedirectToAction(action, controller, new { language = model.CurrentLanguage });
        }
    }
}
