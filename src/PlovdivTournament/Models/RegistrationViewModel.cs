using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Models
{
    public class RegistrationViewModel : MasterViewModel
    {
        [Required(ErrorMessage = "The Password field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Confirm Password field is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The Email field is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The first name field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The middle name field is required.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "The last name field is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The EGN field is required.")]
        public string EGN { get; set; }

        [Required(ErrorMessage = "The phone field is required.")]
        public string Phone { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "The country field is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "The city field is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The state field is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "The zip field is required.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "The street field is required.")]
        public string DeliveryLine { get; set; }

        [Required(ErrorMessage = "The club name field is required.")]
        public string ClubName { get; set; }

        public string ClubInfo { get; set; }

        public bool IsSubscribedForNewsFeed { get; set; }
    }
}