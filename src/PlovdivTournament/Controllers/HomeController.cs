using NHibernate;
using NHibernate.Linq;
using System.Linq;
using PlovdivTournament.Web.Models;
using PlovdivTournament.Entities.Entity;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class HomeController : MasterController
    {
        [HttpGet]
        public ActionResult Index(string language)
        {
            HomeViewModel model = new HomeViewModel();

            if (!string.IsNullOrWhiteSpace(language))
                model.CurrentLanguage = language;
            else if (HttpContext.Request.Cookies.AllKeys.Contains("Language"))
                model.CurrentLanguage = HttpContext.Request.Cookies["Language"].Value;

            var content = Session.Query<Content>().FirstOrDefault(x => x.Page == "Home" && x.Language == model.CurrentLanguage);

            if (content != null)
            {
                var html = content.PageContent;

                html = html.Replace("contenteditable=\"true\"", "contenteditable=\"false\"");

                model.PageContent = html;
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(HomeViewModel model)
        {
            this.TryUpdateModel(model);
            if (this.ModelState.IsValid)
            {
                MvcApplication.SecurityManager.AuthenticateUser(model.LoginEmail, model.LoginPassword);
            }

            return RedirectToAction("Index", "Home");
        }

        public void Logout()
        {
            MvcApplication.SecurityManager.Logout();
            Response.Redirect("/");
        }
    }
}