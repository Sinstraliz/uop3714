using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Models
{
    public class HtmlContentModel : MasterViewModel
    {
        public HtmlContentModel() { }

        public HtmlContentModel(string content)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}