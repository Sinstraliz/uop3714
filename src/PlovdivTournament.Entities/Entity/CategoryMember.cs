using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class CategoryMember
    {
        public CategoryMember() { }

        public CategoryMember(IList<Participant> participants)
        {
            Participants = participants;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual Club Club { get; set; }

        public virtual Category Category { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }

        public virtual IList<Participant> Participants { get; set; }
    }
    public class CategoryMemberMap : ClassMap<CategoryMember>
    {
        public CategoryMemberMap()
        {
            Table("CategoyMembers");
            Id(x => x.Id);
            Map(x => x.Name, "Name");
            References(x => x.Club);
            References(x => x.Category);
            References(x => x.AgeGroup);
            HasManyToMany(x => x.Participants).Cascade.None();
        }
    }
}