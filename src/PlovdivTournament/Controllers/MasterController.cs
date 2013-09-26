using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class MasterController : Controller
    {
        public ISession Session { get; set; }

        public SecurityManager SecurityManager { get; set; }

        [HttpPost]
        public ActionResult ChangeLanguage(MasterViewModel model)
        {
            HttpContext.Response.Cookies.Add(new HttpCookie("Language", model.CurrentLanguage));

            var controller = model.Page.Substring(0, model.Page.IndexOf('/'));

            var action = model.Page.Substring(model.Page.IndexOf('/') + 1, model.Page.Length - model.Page.IndexOf('/') - 1);

            if (action == "Login")
                action = "Index";

            return RedirectToAction(action, controller);
        }

        protected void LoadLanguage(dynamic model)
        {
            if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;
            else
                model.CurrentLanguage = "Bulgarian";
        }

        protected void LoadContent(dynamic model, string page)
        {
            string language = model.CurrentLanguage;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == page && x.Language == language);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
        }
    }
}