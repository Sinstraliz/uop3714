using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Club
    {
        public Club() { }

        public Club(string name, string info, User owner)
        {
            Name = name;
            Info = info;
            Owner = owner;
            Members = new List<Participant>();
        }

        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Info { get; set; }

        public virtual User Owner { get; set; }

        public virtual IList<Participant> Members { get; set; }
    }

    public class ClubMap : ClassMap<Club>
    {
        public ClubMap()
        {
            Table("Clubs");
            Id(x => x.Id, "Club_Id");
            Map(x => x.Name, "Name");
            Map(x => x.Info, "Info");
            References(x => x.Owner, "Owner_Id");
            HasMany(x => x.Members);
        }
    }
}