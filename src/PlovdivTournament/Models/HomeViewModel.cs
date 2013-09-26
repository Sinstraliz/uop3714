using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace PlovdivTournament.Web.Models
{
    public class HomeViewModel : MasterViewModel
    {
        public HomeViewModel()
        {

        }

        [Required(ErrorMessage = "И-майлът е задължителен")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        public string LoginPassword { get; set; }
    }
}