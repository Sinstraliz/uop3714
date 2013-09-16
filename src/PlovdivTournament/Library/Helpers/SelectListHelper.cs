using NHibernate;
using PlovdivTournament.Entities.Entity;
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
            "Animals",
            "Art",
            "Nature",
            "Charity",
            "City",
            "Computer",
            "Cute"
        };

        public static IEnumerable<SelectListItem> GetCategories(string selected)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "--Category--",
                    Value = string.Empty,
                    Selected = selected == string.Empty
                }
            };

            foreach (var categorie in categories)
            {
                result.Add(new SelectListItem { Text = categorie, Selected = categorie == selected, Value = categorie });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> GetDisciplines(IList<Discipline> disciplines)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "--Discipline--",
                    Value = string.Empty
                }
            };

            foreach (var discipline in disciplines)
            {
                result.Add(new SelectListItem { Text = discipline.DisciplineName, Value = discipline.Id.ToString() });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> GetTournamentCategories(IList<Category> categories)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "--Category--",
                    Value = string.Empty
                }
            };

            foreach (var categorie in categories)
            {
                result.Add(new SelectListItem { Text = categorie.CategoryName, Value = categorie.Id.ToString() });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> GetDisciplineAgeGroups(IList<AgeGroup> ageGroups)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "--Age--",
                    Value = string.Empty
                }
            };

            foreach (var ageGroup in ageGroups)
            {
                result.Add(new SelectListItem { Text = ageGroup.Name, Value = ageGroup.Id.ToString() });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> GetClubMembers(IList<Participant> members)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "--Member--",
                    Value = string.Empty
                }
            };

            foreach (var member in members)
            {
                result.Add(new SelectListItem { Text = string.Format("{0} {1} {2} {3}", member.FirstName, member.MiddleName, member.LastName, member.EGN), Value = member.Id.ToString() });
            }

            return result;
        }

        public static IEnumerable<SelectListItem> GetTournaments(IList<Tournament> tournaments)
        {
            var result = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "--Tournament--",
                    Value = string.Empty
                }
            };

            foreach (var tournament in tournaments)
            {
                result.Add(new SelectListItem { Text = tournament.Name, Value = tournament.Id.ToString() });
            }

            return result;
        }
    }
}