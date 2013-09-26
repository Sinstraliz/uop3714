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
using PlovdivTournament.Web.Library.Comparers;

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


            LoadLanguage(model);

            model.Tournaments = Session.Query<Tournament>().ToList();

            if (!model.UserIsAuthenticated)
            {
                ModelState.AddModelError("Not logged in", "За да видите тази страница първо трябва да влезнете във вашия профил");

                return View(model);
            }

            model.CurrentClub = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(RegisterViewModel model)
        {

            LoadLanguage(model);

            model.Tournaments = Session.Query<Tournament>().ToList();

            model.CurrentClub = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            if (model.SelectedTournamentId != Guid.Empty)
                model.SelectedTournament = Session.Query<Tournament>().FirstOrDefault(x => x.Id == model.SelectedTournamentId);

            if (model.SelectedDisciplineId != Guid.Empty)
            {
                model.SelectedDiscipline = Session.Query<Discipline>().FirstOrDefault(x => x.Id == model.SelectedDisciplineId);

                model.Categories = model.SelectedDiscipline.Categories;

                if (model.SelectedDiscipline.Categories.Count == 1)
                {
                    model.SelectedCategory = model.SelectedDiscipline.Categories[0];
                    model.SelectedCategoryId = model.SelectedDiscipline.Categories[0].Id;
                }
            }

            if (model.SelectedCategoryId != Guid.Empty)
            {
                model.SelectedCategory = Session.Query<Category>().FirstOrDefault(x => x.Id == model.SelectedCategoryId);
                model.AgeGroups = model.SelectedCategory.AgeGroups;

                if (model.SelectedCategory.AgeGroups.Count == 1)
                {
                    model.SelectedAgeGroup = model.SelectedCategory.AgeGroups[0];
                    model.SelectedAgeGroupId = model.SelectedCategory.AgeGroups[0].Id;
                }
            }

            if (model.SelectedAgeGroupId != Guid.Empty)
            {
                model.SelectedAgeGroup = Session.Query<AgeGroup>().FirstOrDefault(x => x.Id == model.SelectedAgeGroupId);

                try
                {
                    model.RegisteredMembers = Session.Query<CategoryMember>().Where(x => x.Category == model.SelectedCategory && x.AgeGroup == model.SelectedAgeGroup && x.Club == model.CurrentClub).ToList();

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

            LoadLanguage(model);

            model.Tournaments = Session.Query<Tournament>().ToList();
            model.CurrentClub = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            if (model.SelectedTournamentId != Guid.Empty)
                model.SelectedTournament = Session.Query<Tournament>().FirstOrDefault(x => x.Id == model.SelectedTournamentId);

            if (model.SelectedDisciplineId != Guid.Empty)
            {
                model.SelectedDiscipline = Session.Query<Discipline>().FirstOrDefault(x => x.Id == model.SelectedDisciplineId);

                model.Categories = model.SelectedDiscipline.Categories;

                if (model.SelectedDiscipline.Categories.Count == 1)
                {
                    model.SelectedCategory = model.SelectedDiscipline.Categories[0];
                    model.SelectedCategoryId = model.SelectedDiscipline.Categories[0].Id;
                }
            }

            if (model.SelectedCategoryId != Guid.Empty)
            {
                model.SelectedCategory = Session.Query<Category>().FirstOrDefault(x => x.Id == model.SelectedCategoryId);
                model.AgeGroups = model.SelectedCategory.AgeGroups;

                if (model.SelectedCategory.AgeGroups.Count == 1)
                {
                    model.SelectedAgeGroup = model.SelectedCategory.AgeGroups[0];
                    model.SelectedAgeGroupId = model.SelectedCategory.AgeGroups[0].Id;
                }
            }

            if (model.SelectedAgeGroupId != Guid.Empty)
            {
                model.SelectedAgeGroup = Session.Query<AgeGroup>().FirstOrDefault(x => x.Id == model.SelectedAgeGroupId);

                try
                {
                    model.RegisteredMembers = Session.Query<CategoryMember>().Where(x => x.Category == model.SelectedCategory && x.AgeGroup == model.SelectedAgeGroup && x.Club == model.CurrentClub).ToList();

                }
                catch (NullReferenceException ex)
                {
                    model.RegisteredMembers = new List<CategoryMember>();
                }
            }

            if (string.IsNullOrWhiteSpace(model.SelectedClubMembers))
            {
                ModelState.AddModelError("Invalid number of participants", String.Format("В тази категория може да има минимум {0} участник/а", model.SelectedCategory.MinNumberOfParticipants));

                return View("Index", model);
            }

            var selectedClubMembersIds = model.SelectedClubMembers.Remove(0, 1).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (selectedClubMembersIds.Count < model.SelectedCategory.MinNumberOfParticipants)
            {
                ModelState.AddModelError("Invalid number of participants", String.Format("В тази категория може да има минимум {0} участник/а", model.SelectedCategory.MinNumberOfParticipants));

                return View("Index", model);
            }

            var selectedClubMembers = new List<Participant>();

            var lowerAgeParticipants = 0;

            foreach (var id in selectedClubMembersIds)
            {
                var participant = Session.Query<Participant>().FirstOrDefault(x => x.Id.ToString().ToLower() == id.Trim());

                if (selectedClubMembers.Contains(participant))
                {
                    ModelState.AddModelError("Participant exists", String.Format("Този участник: {0} {1} {2} {3} вече участва в тази {4}", participant.FirstName, participant.MiddleName, participant.LastName, participant.EGN, model.SelectedCategory.CategoryName));

                    return View("Index", model);
                }

                selectedClubMembers.Add(participant);

                foreach (var member in model.SelectedCategory.CategoryMembers)
                {
                    if (member.Participants.Contains(participant))
                    {
                        ModelState.AddModelError("Participant exists", String.Format("Този участник: {0} {1} {2} {3} вече участва в тази категория", participant.FirstName, participant.MiddleName, participant.LastName, participant.EGN));

                        return View("Index", model);
                    }
                }

                var age = GetAgeFromEGN(participant.EGN);

                if (age < model.SelectedAgeGroup.MinimumAge)
                    lowerAgeParticipants++;
            }

            var lowerAgeParticipantsPercentage = 0.0;

            if (lowerAgeParticipants > 0)
                lowerAgeParticipantsPercentage = lowerAgeParticipants / selectedClubMembersIds.Count * 100;

            if (lowerAgeParticipantsPercentage > 50)
            {
                ModelState.AddModelError("Invalid participants", "Не може да имате повече от 50% участници от друга възрастова група");

                return View("Index", model);
            }

            if (string.IsNullOrWhiteSpace(model.DanceName))
            {
                ModelState.AddModelError("DanceName", "Името на танца е задължително");

                return View("Index", model);
            }

            if (model.SelectedCategory.CategoryMembers == null)
                model.SelectedCategory.CategoryMembers = new List<CategoryMember>();

            var categoryMember = new CategoryMember();
            categoryMember.Participants = new List<Participant>();
            categoryMember.Category = model.SelectedCategory;
            categoryMember.Name = model.DanceName;
            categoryMember.AgeGroup = model.SelectedAgeGroup;
            categoryMember.Club = Session.Query<User>().FirstOrDefault(x => x.Id == SecurityManager.AuthenticatedUser.Id).Club;

            Session.Save(categoryMember);

            categoryMember.Participants = selectedClubMembers;

            model.SelectedCategory.CategoryMembers.Add(categoryMember);

            Session.SaveOrUpdate(model.SelectedCategory);

            model.DanceName = string.Empty;
            model.SelectedClubMembers = string.Empty;

            try
            {
                model.RegisteredMembers = Session.Query<CategoryMember>().Where(x => x.Category == model.SelectedCategory && x.AgeGroup == model.SelectedAgeGroup && x.Club == model.CurrentClub).ToList();

            }
            catch (NullReferenceException ex)
            {
                model.RegisteredMembers = new List<CategoryMember>();
            }

            return View("Index", model);
        }

        [HttpPost]
        public void RemoveCategoryMember(Guid memberId)
        {
            var user = Session.Query<User>().Where(x => x.Id == SecurityManager.AuthenticatedUser.Id).FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var member = Session.Query<CategoryMember>().Where(x => x.Id == memberId).FirstOrDefault();
            if (member == null)
            {
                throw new InvalidOperationException();
            }

            Session.Delete(member);
        }

        //[HttpPost]
        //public void EditCategoryMember(Guid memberId)
        //{
        //    throw new NotImplementedException();
        //}

        private int GetAgeFromEGN(string egn)
        {
            var participantYear = int.Parse(egn.Substring(0, 2));

            var currentYear = int.Parse(DateTime.Now.Year.ToString().Substring(2, 2));

            if (participantYear > currentYear || (participantYear == currentYear && (egn[2] == '4' || egn[2] == '5')))
                currentYear += 100;

            return currentYear - participantYear;
        }
    }
}