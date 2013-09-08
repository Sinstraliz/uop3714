using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Models
{
    public class EditProfileViewModel : MasterViewModel
    {
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string EGN { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string DeliveryLine { get; set; }

        public bool IsSubscribedForNewsFeed { get; set; }

        public HttpPostedFileBase NewAvatar { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Password do not match")]
        public string RepeatPassword { get; set; }
    }
}