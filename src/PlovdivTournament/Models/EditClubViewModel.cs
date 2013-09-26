using DataAnnotationsExtensions;
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
        [Required(ErrorMessage = "Името на клуба е задължително")]
        public string ClubName { get; set; }

        public string Info { get; set; }

        public List<Participant> Members { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Бащиното име е задължително")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължително")]
        public string LastName { get; set; }

        [Digits(ErrorMessage = "ЕГН-то може да съдържа само цифри")]
        [Required(ErrorMessage = "ЕГН-то е задължително")]
        [StringLength(10, ErrorMessage = "Невалидно ЕГН")]
        public string EGN { get; set; }

        [Digits(ErrorMessage = "Лиценза може да съдържа само цифри")]
        public string LicenceNumber { get; set; }

        public User Owner { get; set; }
    }
}