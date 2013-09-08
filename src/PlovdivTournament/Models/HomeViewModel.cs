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

        [Required(ErrorMessage = "Username is required")]
        public string LoginEmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string LoginPassword { get; set; }
    }
}