using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class ClubController : Controller
    {
        public ISession Session { get; set; }

        public SecurityManager SecurityManager { get; set; }

        public ActionResult Index()
        {
            User user = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            Club club = Session.Get<Club>(user.Club.Id);

            ClubViewModel model = new ClubViewModel(club.Name, club.Info, club.Owner, club.Members.ToList());

            return View(model);
        }

        public ActionResult Preview(Guid id)
        {
            Club club = Session.Get<Club>(id);

            ClubViewModel model = new ClubViewModel(club.Name, club.Info, club.Owner, club.Members.ToList());

            return View(model);
        }

        public ActionResult Edit()
        {
            var model = new EditClubViewModel();

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            model.ClubName = currentUser.Club.Name;
            model.Info = currentUser.Club.Info;
            model.Members = currentUser.Club.Members.ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Save(EditClubViewModel model)
        {
            TryValidateModel(model);

            if (!ModelState.IsValid)
                return View("Edit", model);

            User currentUser = Session.Get<User>(SecurityManager.AuthenticatedUser.Id);

            currentUser.Club.Name = model.ClubName;
            currentUser.Club.Info = model.Info;
            currentUser.Club.Members = model.Members;

            SecurityManager.Logout();
            SecurityManager.AuthenticateUser(currentUser.Email, currentUser.Password);

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

            Session.Delete(member);

            var model = new EditClubViewModel();
            model.ClubName = user.Club.Name;
            model.Info = user.Club.Info;
            model.Members = user.Club.Members.ToList();

            return PartialView("MembersPartialView", model);
        }

        [HttpPost]
        public ActionResult AddMember(string firstName, string middleName, string lastName, string egn, string licenceNumber)
        {
            var user = Session.Query<User>().Where(x => x.Id == SecurityManager.AuthenticatedUser.Id).FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            if (string.IsNullOrEmpty(licenceNumber))
                licenceNumber = string.Empty;

            var model = new EditClubViewModel();
            model.ClubName = user.Club.Name;
            model.Info = user.Club.Info;
            model.Members = user.Club.Members.ToList();

            var member = Session.Query<Participant>().Where(x => x.EGN == egn).FirstOrDefault();

            if (member != null)
            {
                model.Error = "There is already a member with that EGN in club with name:" + member.Club.Name;

                return PartialView("MembersPartialView", model);
            }

            member = new Participant(firstName, middleName, lastName, egn, licenceNumber, user.Club);

            Session.Save(member);

            model.Members.Add(member);

            return PartialView("/Views/Club/PartialViews/MembersPartialView.cshtml", model);
        }
    }
}