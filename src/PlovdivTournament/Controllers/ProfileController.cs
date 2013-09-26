﻿using NHibernate;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Models;
using System;
using System.IO;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class ProfileController : MasterController
    {
        public ActionResult Index()
        {
            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);
            var avatar = currentUser.Avatar;

            if (avatar == null)
                avatar = Session.Load<Avatar>(Avatar.DefaultAvatarId);

            var model = new ProfileViewModel(avatar, currentUser.Email, currentUser.FirstName, currentUser.MiddleName, currentUser.LastName, currentUser.EGN, currentUser.Phone, currentUser.Fax, currentUser.Address);


            LoadLanguage(model);

            return View(model);
        }

        public ActionResult Preview(Guid id)
        {
            User currentUser = Session.Get<User>(id);
            var avatar = currentUser.Avatar;

            if (avatar == null)
                avatar = Session.Load<Avatar>(Avatar.DefaultAvatarId);

            var model = new ProfileViewModel(avatar, currentUser.Email, currentUser.FirstName, currentUser.MiddleName, currentUser.LastName, currentUser.EGN, currentUser.Phone, currentUser.Fax, currentUser.Address);

            LoadLanguage(model);

            return View(model);
        }

        public ActionResult Edit()
        {
            var model = new EditProfileViewModel();

            LoadLanguage(model);

            User user = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            model.FirstName = user.FirstName;
            model.MiddleName = user.MiddleName;
            model.LastName = user.LastName;
            model.EGN = user.EGN;
            model.Email = user.Email;
            model.Phone = user.Phone;
            model.Fax = user.Fax;
            model.Country = user.Address.Country;
            model.City = user.Address.City;
            model.State = user.Address.State;
            model.Zip = user.Address.Zip;
            model.DeliveryLine = user.Address.DeliveryLine;
            model.IsSubscribedForNewsFeed = user.IsSubscribedForNewsFeed;

            return View(model);
        }


        [HttpPost]
        public ActionResult Save(EditProfileViewModel model)
        {
            LoadLanguage(model);

            ModelState["OldPassword"].Errors.Clear();
            ModelState["NewPassword"].Errors.Clear();
            ModelState["RepeatPassword"].Errors.Clear();

            if (!ModelState.IsValid)
                return View("Edit", model);

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            currentUser.FirstName = model.FirstName;
            currentUser.MiddleName = model.MiddleName;
            currentUser.LastName = model.LastName;
            currentUser.EGN = model.EGN;
            currentUser.Email = model.Email;
            currentUser.Phone = model.Phone;
            currentUser.Fax = model.Fax;
            currentUser.Address.Country = model.Country;
            currentUser.Address.City = model.City;
            currentUser.Address.State = model.State;
            currentUser.Address.Zip = model.Zip;
            currentUser.Address.DeliveryLine = model.DeliveryLine;
            currentUser.IsSubscribedForNewsFeed = model.IsSubscribedForNewsFeed;

            if (model.NewAvatar != null)
            {
                Avatar newAvatar = currentUser.Avatar;
                MemoryStream target = new MemoryStream();
                model.NewAvatar.InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                //Session.Delete(newAvatar);
                newAvatar = new Avatar(Guid.NewGuid(), data, currentUser, DateTime.Now, model.NewAvatar.ContentType);
                currentUser.Avatar = newAvatar;
                Session.Save(newAvatar);
            }

            SecurityManager.Logout();
            SecurityManager.AuthenticateUser(currentUser.Email, currentUser.Password);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var model = new EditProfileViewModel();


            LoadLanguage(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(EditProfileViewModel model)
        {
                        
            LoadLanguage(model);

            ModelState["FirstName"].Errors.Clear();
            ModelState["MiddleName"].Errors.Clear();
            ModelState["LastName"].Errors.Clear();
            ModelState["EGN"].Errors.Clear();
            ModelState["Phone"].Errors.Clear();
            ModelState["Country"].Errors.Clear();
            ModelState["City"].Errors.Clear();
            ModelState["State"].Errors.Clear();
            ModelState["Zip"].Errors.Clear();
            ModelState["DeliveryLine"].Errors.Clear();

            if (!ModelState.IsValid)
                return View("ChangePassword", model);

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            if (!String.IsNullOrEmpty(model.NewPassword))
            {

                if (model.OldPassword == currentUser.Password)
                {
                    if (currentUser.Password != model.NewPassword)
                        currentUser.Password = model.NewPassword;
                    else
                        ModelState.AddModelError("samePass", "Моля изберете различна парола");
                }
                else
                {
                    ModelState.AddModelError("invPass", "Invalid password");
                    model.OldPassword = string.Empty;
                    model.NewPassword = string.Empty;
                    model.RepeatPassword = string.Empty;

                    return View("ChangePassword", model);
                }
            }
            else
            {
                ModelState.AddModelError("invPass", "Невалидна парола");
            }

            return RedirectToAction("Index");
        }
    }
}