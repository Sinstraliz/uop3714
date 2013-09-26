using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Models
{
    public class EditProfileViewModel : MasterViewModel
    {
        [Email(ErrorMessage = "Невалиден е-майл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Имтеро е задължително")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Бащиното име е задължително")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължителна")]
        public string LastName { get; set; }

        [Digits(ErrorMessage = "ЕГН-то може да съдържа само цифри")]
        [Required(ErrorMessage = "ЕГН-то е задължително")]
        [StringLength(10, ErrorMessage = "Невалидно ЕГН")]
        public string EGN { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        public string Phone { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "Държавата е задължителна")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Градът е задължителен")]
        public string City { get; set; }

        [Required(ErrorMessage = "Областта е задължителна")]
        public string State { get; set; }

        [Required(ErrorMessage = "Пощенският код е задължителен")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Улицата е задължителна")]
        public string DeliveryLine { get; set; }

        public bool IsSubscribedForNewsFeed { get; set; }

        public HttpPostedFileBase NewAvatar { get; set; }

        [Required(ErrorMessage = "Моля въведете старата си парола")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Моля въведете новата си парола")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Паролата ви не съвпада")]
        [Required(ErrorMessage = "Моля въведете повторно новата си парола")]
        public string RepeatPassword { get; set; }
    }
}