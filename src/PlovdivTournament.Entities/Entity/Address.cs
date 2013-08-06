using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class Address
    {
        public Address() { }

        public virtual Guid Id { get; set; }

        public virtual string Country { get; set; }

        public virtual string City { get; set; }

        public virtual string Zip { get; set; }

        public virtual string DeliveryLine { get; set; }

        public virtual User User { get; set; }
    }

    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Address");
            Id(x => x.Id);
            Map(x => x.Country, "Country");
            Map(x => x.City, "City");
            Map(x => x.Zip, "Zip");
            Map(x => x.DeliveryLine, "DeliveryLine");
            References(x => x.User, "User_Id");
        }
    }
}