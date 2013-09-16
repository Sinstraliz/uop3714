using NHibernate;
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

            return RedirectToAction(action, controller, new { language = model.CurrentLanguage });
        }
    }
}