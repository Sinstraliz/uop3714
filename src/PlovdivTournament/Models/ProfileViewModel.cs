using PlovdivTournament.Entities.Entity;

namespace PlovdivTournament.Web.Models
{
    public class ProfileViewModel : MasterViewModel
    {
        public ProfileViewModel(Image avatar, string email, string firstName, string middleName, string lastName, string egn, string phone, string fax, Address address)
        {
            Avatar = avatar;
            Email = email;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EGN = egn;
            Phone = phone;
            Fax = fax;
            Country = address.Country;
            City = address.City;
            State = address.State;
            Zip = address.Zip;
            DeliveryLine = address.DeliveryLine;
        }

        public Image Avatar { get; set; }

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
    }
}