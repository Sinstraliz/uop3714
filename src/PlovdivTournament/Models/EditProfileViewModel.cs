using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Models
{
    public class EditProfileViewModel
    {
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid e-mail")]
        public string Email { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Fax { get; set; }

        public HttpPostedFileBase NewAvatar { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Password do not match")]
        public string RepeatPassword { get; set; }
    }
}