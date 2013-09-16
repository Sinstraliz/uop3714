using NHibernate;
using NHibernate.Linq;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Controllers
{
    public class RegisterController : MasterController
    {
        public ISession Session { get; set; }

        public SecurityManager SecurityManager { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new RegisterViewModel();

            model.Tournaments = Session.Query<Tournament>().ToList();
            model.CurrentClub = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(RegisterViewModel model)
        {
            model.Tournaments = Session.Query<Tournament>().ToList();
            model.CurrentClub = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            if (model.SelectedTournamentId != Guid.Empty)
                model.SelectedTournament = Session.Query<Tournament>().FirstOrDefault(x => x.Id == model.SelectedTournamentId);

            if (model.SelectedDisciplineId != Guid.Empty)
                model.SelectedDiscipline = Session.Query<Discipline>().FirstOrDefault(x => x.Id == model.SelectedDisciplineId);

            if (model.SelectedCategoryId != Guid.Empty)
                model.SelectedCategory = Session.Query<Category>().FirstOrDefault(x => x.Id == model.SelectedCategoryId);

            if (model.SelectedAgeGroupId != Guid.Empty)
            {
                model.SelectedAgeGroup = Session.Query<AgeGroup>().FirstOrDefault(x => x.Id == model.SelectedAgeGroupId);

                try
                {
                    model.RegisteredMembers = Session.Query<CategoryMember>().Where(x => x.Category == model.SelectedCategory && x.Category.AgeGroup == model.SelectedAgeGroup && x.Club == model.CurrentClub).ToList();

                }
                catch (NullReferenceException ex)
                {
                    model.RegisteredMembers = new List<CategoryMember>();
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(RegisterViewModel model)
        {
            var selectedClubMembersIds = model.SelectedClubMembers.Remove(0, 1).Split(new char[','], StringSplitOptions.RemoveEmptyEntries).ToList();

            var category = Session.Query<Category>().FirstOrDefault(x => x.Id == model.SelectedCategoryId);

            if (category.CategoryMembers == null)
                category.CategoryMembers = new List<CategoryMember>();

            var categoryMember = new CategoryMember();
            categoryMember.Participants = new List<Participant>();
            categoryMember.Category = category;
            categoryMember.Name = model.DanceName;
            categoryMember.Club = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            Session.Save(categoryMember);

            foreach (var id in selectedClubMembersIds)
            {
                categoryMember.Participants.Add(Session.Query<Participant>().FirstOrDefault(x => x.Id.ToString().ToLower() == id.Trim()));
            }

            category.CategoryMembers.Add(categoryMember);

            Session.SaveOrUpdate(category);

            return RedirectToAction("Index");
        }
    }
}