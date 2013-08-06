using System;

namespace PlovdivTournament.Web.Library.IdentityAndAccess
{
    public class UserInfo
    {
        public UserInfo(Guid id, string username, string email, bool isAdmin)
        {
            Id = id;
            Username = username;
            Email = email;
            IsAdmin = isAdmin;
        }

        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public bool IsAdmin { get; set; }
    }
}