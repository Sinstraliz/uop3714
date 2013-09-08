using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class Address
    {
        public Address() { }

        public Address(string country, string city, string state, string zip, string deliveryLine, User owner)
        {
            Country = country;
            City = city;
            State = state;
            Zip = zip;
            DeliveryLine = deliveryLine;
            Owner = owner;
        }

        public virtual Guid Id { get; set; }

        public virtual string Country { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string Zip { get; set; }

        public virtual string DeliveryLine { get; set; }

        public virtual User Owner { get; set; }
    }

    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Address");
            Id(x => x.Id);
            Map(x => x.Country, "Country");
            Map(x => x.City, "City");
            Map(x => x.State, "State");
            Map(x => x.Zip, "Zip");
            Map(x => x.DeliveryLine, "DeliveryLine");
            References(x => x.Owner, "Owner_Id");
        }
    }
}