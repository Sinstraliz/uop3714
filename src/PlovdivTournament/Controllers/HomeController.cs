using NHibernate;
using NHibernate.Linq;
using System.Linq;
using PlovdivTournament.Web.Models;
using PlovdivTournament.Entities.Entity;
using System.Web.Mvc;
using System;

namespace PlovdivTournament.Web.Controllers
{
    public class HomeController : MasterController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new HomeViewModel();

            LoadLanguage(model);

            if (string.IsNullOrWhiteSpace(model.PageContent))
                LoadContent(model, "Home");

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(HomeViewModel model)
        {

            LoadLanguage(model);

            if (string.IsNullOrWhiteSpace(model.PageContent))
                LoadContent(model, "Home");

            this.TryUpdateModel(model);

            var isAuthenticated = false;

            if (this.ModelState.IsValid)
            {
                isAuthenticated = MvcApplication.SecurityManager.AuthenticateUser(model.LoginEmail, model.LoginPassword);
            }

            if (!isAuthenticated && this.ModelState.IsValid)
                ModelState.AddModelError("Failed login", "Грешен е-майл и/или парола");

            return View("Index", model);
        }

        public void Logout()
        {
            MvcApplication.SecurityManager.Logout();
            Response.Redirect("/");
        }
    }
}