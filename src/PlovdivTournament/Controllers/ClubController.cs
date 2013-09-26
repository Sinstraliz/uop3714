using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Library.ExtensionMethods;
using PlovdivTournament.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace PlovdivTournament.Web.Controllers
{
    public class ClubController : MasterController
    {
        public ActionResult Index()
        {
            User user = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            Club club = Session.Get<Club>(user.Club.Id);

            ClubViewModel model = new ClubViewModel(club.Name, club.Info, club.Owner, club.Members.ToList());


            LoadLanguage(model);

            return View(model);
        }

        public ActionResult Preview(Guid id)
        {
            Club club = Session.Get<Club>(id);

            ClubViewModel model = new ClubViewModel(club.Name, club.Info, club.Owner, club.Members.ToList());


            LoadLanguage(model);

            return View(model);
        }

        public ActionResult Edit()
        {
            var model = new EditClubViewModel();


            LoadLanguage(model);

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            model.ClubName = currentUser.Club.Name;
            model.Info = currentUser.Club.Info;
            model.Members = currentUser.Club.Members.ToList();
            model.Owner = currentUser;

            return View(model);
        }


        [HttpPost]
        public ActionResult Save(EditClubViewModel model)
        {
            LoadLanguage(model);

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            model.Members = currentUser.Club.Members.ToList();

            ModelState["FirstName"].Errors.Clear();
            ModelState["MiddleName"].Errors.Clear();
            ModelState["LastName"].Errors.Clear();
            ModelState["EGN"].Errors.Clear();

            if (!ModelState.IsValid)
                return View("Edit", model);

            currentUser.Club.Name = model.ClubName;
            currentUser.Club.Info = model.Info;

            Session.Update(currentUser);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveMember(Guid memberId)
        {
            var user = Session.Query<User>().Where(x => x.Id == SecurityManager.AuthenticatedUser.Id).FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var member = Session.Query<Participant>().Where(x => x.Id == memberId).FirstOrDefault();
            if (member == null)
            {
                throw new InvalidOperationException();
            }

            var model = new EditClubViewModel();


            LoadLanguage(model);

            model.ClubName = user.Club.Name;
            model.Info = user.Club.Info;
            model.Members = user.Club.Members.ToList();

            Session.Delete(member);

            model.Members.Remove(member);

            return PartialView("MembersPartialView", model);
        }

        [HttpPost]
        public ActionResult AddMember(EditClubViewModel model)
        {

            LoadLanguage(model);

            var user = Session.Query<User>().Where(x => x.Id == SecurityManager.AuthenticatedUser.Id).FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            if (string.IsNullOrEmpty(model.LicenceNumber))
                model.LicenceNumber = string.Empty;

            var member = Session.Query<Participant>().Where(x => x.EGN == model.EGN).FirstOrDefault();

            if (member != null)
            {
                ModelState.AddModelError("Member exists", string.Format("Вече съществува член на клуб {0} с това ЕГН", member.Club.Name));

                return PartialView("MembersPartialView", model);
            }

            member = new Participant(model.FirstName, model.MiddleName, model.LastName, model.EGN, model.LicenceNumber, user.Club);

            Session.Save(member);

            if (model.Members == null)
                model.Members = new List<Participant>();

            model.Members.Add(member);

            return Json(new Object[] { false, this.RenderPartialViewToString("MembersPartialView", model) });
        }
    }
}