using System.ComponentModel.DataAnnotations;

namespace PlovdivTournament.Web.Models
{
    public class HomeViewModel : MasterViewModel
    {
        public HomeViewModel()
        {

        }

        [Required(ErrorMessage = "Username is required")]
        public string LoginUserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string LoginPassword { get; set; }
    }
}