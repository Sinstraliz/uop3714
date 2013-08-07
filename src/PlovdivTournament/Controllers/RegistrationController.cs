using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class RegistrationController : Controller
    {
        public ISession Session { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            RegistrationViewModel model = new RegistrationViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var user = Session.Query<User>().Where(x => x.Email == model.Email).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("Unique", "Username and e-mail must be unique.");
                return View("Index", model);
            }

            var newUser = new User(Guid.NewGuid(), model.Password, model.Email, model.FirstName, model.MiddleName, model.LastName, model.EGN, model.Phone, model.Fax);
            newUser.Avatar = Session.Load<Avatar>(Avatar.DefaultAvatarId);
            Session.Save(newUser);

            return RedirectToAction("Index", "Home");
        }
    }
}