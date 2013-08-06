using NHibernate;
using PlovdivTournament.Web.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
namespace PlovdivTournament.Web.Controllers
{
    public class HomeController : Controller
    {
        public ISession Session { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(HomeViewModel model)
        {
            this.TryUpdateModel(model);
            if (this.ModelState.IsValid)
            {
                MvcApplication.SecurityManager.AuthenticateUser(model.LoginUserName, model.LoginPassword);
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