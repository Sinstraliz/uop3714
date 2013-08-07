using System;

namespace PlovdivTournament.Web.Library.IdentityAndAccess
{
    public class UserInfo
    {
        public UserInfo(Guid id, string email, bool isAdmin)
        {
            Id = id;
            Email = email;
            IsAdmin = isAdmin;
        }

        public Guid Id { get; private set; }

        public string Email { get; private set; }

        public bool IsAdmin { get; set; }
    }
}