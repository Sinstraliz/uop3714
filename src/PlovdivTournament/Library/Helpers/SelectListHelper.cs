using NHibernate;
using PlovdivTournament.Entities.Entity;
using PlovdivTournament.Web.Library.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Library.Helpers
{
    public static class SelectListHelper
    {
        private static IEnumerable<string> categories = new List<string> 
        {
            "Класически танц",
            "Модерен танц",
            "Джаз танц",
            "Характерен танц",
            "Танцово шоу",
            "Етно шоу",
            "Латино шоу",
            "Продукции",
            "Acrogym",
            "Hip Hop",
            "Break Dance",
            "Free Open Dance",
            "Party Time Seniors"
        };

        public static IEnumerable<SelectListItem> GetCategories(string selected)
        {
            yield return new SelectListItem()
                {
                    Text = "--Категория--",
                    Value = string.Empty,
                    Selected = selected == string.Empty
                };

            foreach (var categorie in categories)
            {
                yield return new SelectListItem() { Text = categorie, Selected = categorie == selected, Value = categorie };
            }
        }

        public static IEnumerable<SelectListItem> GetDisciplines(IList<Discipline> disciplines)
        {
            yield return new SelectListItem()
                {
                    Text = "--Дисциплина--",
                    Value = string.Empty
                };

            foreach (var discipline in disciplines)
            {
                yield return new SelectListItem() { Text = discipline.DisciplineName, Value = discipline.Id.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetTournamentCategories(IList<Category> categories)
        {
            yield return new SelectListItem()
                {
                    Text = "--Категория--",
                    Value = string.Empty
                };

            var orderedCategories = categories.OrderBy(x => x, new CategoryComparer()).ToList();

            foreach (var categorie in orderedCategories)
            {
                yield return new SelectListItem() { Text = categorie.CategoryName, Value = categorie.Id.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetDisciplineAgeGroups(IList<AgeGroup> ageGroups)
        {
            yield return new SelectListItem()
                {
                    Text = "--Възрастова група--",
                    Value = string.Empty
                };

            var orderedAgeGroups = ageGroups.OrderBy(x => x, new AgeGroupComparer()).ToList();

            foreach (var ageGroup in orderedAgeGroups)
            {
                yield return new SelectListItem() { Text = ageGroup.Name, Value = ageGroup.Id.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetClubMembers(IList<Participant> members, AgeGroup ageGroup)
        {
            yield return new SelectListItem()
                {
                    Text = "--Член--",
                    Value = string.Empty
                };

            var properMembers = new List<Participant>();

            if (ageGroup.AllowedMinimumAge != null)
                properMembers = members.Where(x => GetAgeFromEGN(x.EGN) < ageGroup.MaximumAge && GetAgeFromEGN(x.EGN) > ageGroup.AllowedMinimumAge).OrderBy(x => x.FirstName).ToList();
            else
                properMembers = members.Where(x => GetAgeFromEGN(x.EGN) < ageGroup.MaximumAge && GetAgeFromEGN(x.EGN) > ageGroup.MinimumAge).OrderBy(x => x.FirstName).ToList();

            foreach (var member in properMembers)
            {
                yield return new SelectListItem() { Text = string.Format("{0} {1} {2} {3}", member.FirstName, member.MiddleName, member.LastName, member.EGN), Value = member.Id.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetTournaments(IList<Tournament> tournaments)
        {
            yield return new SelectListItem()
                {
                    Text = "--Турнир--",
                    Value = string.Empty
                };

            foreach (var tournament in tournaments)
            {
                yield return new SelectListItem { Text = tournament.Name, Value = tournament.Id.ToString() };
            }
        }

        private static int GetAgeFromEGN(string egn)
        {
            var participantYear = int.Parse(egn.Substring(0, 2));

            var currentYear = int.Parse(DateTime.Now.Year.ToString().Substring(2, 2));

            if (participantYear > currentYear || (participantYear == currentYear && (egn[2] == '4' || egn[2] == '5')))
                currentYear += 100;

            return currentYear - participantYear;
        }
    }
}