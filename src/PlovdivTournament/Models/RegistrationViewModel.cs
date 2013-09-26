using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Models
{
    public class RegistrationViewModel : MasterViewModel
    {
        [Required(ErrorMessage = "Паролата е задължителна")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Потвърждаването на паролата е задължително")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролата не съвпада")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Е-майлът е задължителен")]
        [Email(ErrorMessage = "Невалиден е-майл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Имтеро е задължително")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Бащиното име е задължително")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължителна")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ЕГН-то е задължително")]
        [Digits(ErrorMessage = "ЕГН-то може да съдържа само цифри")]
        public string EGN { get; set; }

        [Required(ErrorMessage = "Имтеро е задължително")]
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

        [Required(ErrorMessage = "Името на клуба е задължително")]
        public string ClubName { get; set; }

        public string ClubInfo { get; set; }

        public bool IsSubscribedForNewsFeed { get; set; }
    }
}