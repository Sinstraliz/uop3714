using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlovdivTournament.Entities.Entity;

namespace PlovdivTournament.Web.Manage.Models
{
    public class TournamentsViewModel : MasterViewModel
    {
        public TournamentsViewModel()
        {
            Tournaments = new List<Tournament>();
            NewTournament = new Tournament();
        }

        public List<Tournament> Tournaments { get; set; }

        public Tournament SelectedTournament { get; set; }

        public Tournament NewTournament { get; set; }
    }
}