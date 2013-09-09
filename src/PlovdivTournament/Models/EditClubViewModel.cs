using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Models
{
    public class EditClubViewModel : MasterViewModel
    {
        public string ClubName { get; set; }

        public string Info { get; set; }

        public List<Participant> Members { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EGN { get; set; }

        public string LicenceNumber { get; set; }

        public User Owner { get; set; }
    }
}