﻿using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class RegistrationController : MasterController
    {
        [HttpGet]
        public ActionResult Index()
        {
            RegistrationViewModel model = new RegistrationViewModel();

            LoadLanguage(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {

            LoadLanguage(model);

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var user = Session.Query<User>().Where(x => x.Email == model.Email).FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("Unique", "Вече има потребител с този е-майл");

                return View("Index", model);
            }

            var newUser = new User(Guid.NewGuid(), model.Email, model.Password, model.FirstName, model.MiddleName, model.LastName, model.EGN, model.Phone, model.Fax, model.IsSubscribedForNewsFeed);
            //newUser.Avatar = Session.Load<Avatar>(Avatar.DefaultAvatarId);
            newUser.Address = new Address(model.Country, model.City, model.State, model.Zip, model.DeliveryLine, newUser);
            newUser.Club = new Club(model.ClubName, model.ClubInfo, newUser);
            Session.Save(newUser);

            return RedirectToAction("Index", "Home");
        }
    }
}