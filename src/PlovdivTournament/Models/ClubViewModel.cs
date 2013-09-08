using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Models
{
    public class ClubViewModel : MasterViewModel
    {
        public ClubViewModel(string name, string info, User owner, List<Participant> members)
        {
            ClubName = name;
            Info = info;
            Owner = owner;
            Members = members;
        }

        public string ClubName { get; set; }

        public string Info { get; set; }

        public User Owner { get; set; }

        public List<Participant> Members { get; set; }
    }
}