using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Library.Comparers
{
    public class CategoryComparer : IComparer<Category>
    {
        public int Compare(Category x, Category y)
        {
            Dictionary<string, int> values = new Dictionary<string, int>()
            { 
                { "Соло жени", 1 },
                { "Соло мъже", 2 },
                { "Дует", 3 },
                { "Група", 4 },
                { "Формация", 5 },
                { "1 vs 1", 6 },
                { "Отбор", 7 }
            };

            if (values.ContainsKey(x.CategoryName) && values.ContainsKey(y.CategoryName))
                return Comparer<int>.Default.Compare(values[x.CategoryName], values[y.CategoryName]);

            return 100;
        }
    }
}