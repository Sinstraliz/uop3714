using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Library.Comparers
{
    public class AgeGroupComparer : IComparer<AgeGroup>
    {
        public int Compare(AgeGroup x, AgeGroup y)
        {
            Dictionary<string, int> values = new Dictionary<string, int>()
            { 
                { "до 8г.", 1 },
                { "9-11г.", 2 },
                { "12-15г.", 3 },
                { "над 16г.", 4 },
                { "до 12г.", 5 },
                { "над 12г.", 6 }
            };

            if (values.ContainsKey(x.Name) && values.ContainsKey(y.Name))
                return Comparer<int>.Default.Compare(values[x.Name], values[y.Name]);

            return 100;
        }
    }
}