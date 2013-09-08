using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlovdivTournament.Entities.Entity;

namespace PlovdivTournament.Web.Manage.Models
{
    public class TournamentsModel
    {
        public TournamentsModel()
        {
            Tournaments = new List<Tournament>();
            CurrentTournament = new Tournament();
        }
        public List<Tournament> Tournaments { get; set; }
        public Tournament CurrentTournament { get; set; }
    }
}