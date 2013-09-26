using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class User
    {
        protected User() { }

        public User(Guid id, string email, string password, string firstName, string middleName, string lastName, string eGN, string phone, string fax, bool isSubscribedForNewsFeed)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EGN = eGN;
            Phone = phone;
            Fax = fax;
            IsSubscribedForNewsFeed = isSubscribedForNewsFeed;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string EGN { get; set; }

        public virtual string Phone { get; set; }

        public virtual string Fax { get; set; }

        public virtual Address Address { get; set; }

        public virtual Club Club { get; set; }

        public virtual Avatar Avatar { get; set; }

        public virtual bool IsAdmin { get; set; }

        public virtual bool IsChoreographer { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual bool IsSubscribedForNewsFeed { get; set; }
    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id, "User_Id");
            Map(x => x.Email, "Email").Unique();
            Map(x => x.Password, "Password");
            Map(x => x.FirstName, "First_Name");
            Map(x => x.MiddleName, "Middle_Name");
            Map(x => x.LastName, "Last_Name");
            Map(x => x.EGN, "EGN");
            Map(x => x.Phone, "Phone");
            Map(x => x.Fax, "Fax");
            Map(x => x.IsChoreographer, "Is_Choreographer");
            Map(x => x.IsActive, "Is_Active");
            Map(x => x.IsAdmin, "Is_Admin");
            Map(x => x.IsSubscribedForNewsFeed, "Is_Subscribed_For_News_Feed");
            References(x => x.Avatar, "Avatar_Id").Nullable().Cascade.All();
            References(x => x.Address, "Address_Id").Cascade.All();
            References(x => x.Club, "Club_Id").Cascade.All();
        }
    }
}