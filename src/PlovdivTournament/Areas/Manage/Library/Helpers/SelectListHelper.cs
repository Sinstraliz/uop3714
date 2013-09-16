﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Manage.Library.Helpers
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
                    Text = "--Categorie--",
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
    }
}