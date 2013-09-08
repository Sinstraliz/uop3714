using NHibernate;
using PlovdivTournament.Web.Models;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class HomeController : Controller
    {
        public ISession Session { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

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