using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class DisciplineParticipant
    {
        public DisciplineParticipant() { }

        public virtual Guid Id { get; protected set; }

        public virtual Discipline Discipline { get; set; }

        public virtual IList<Participant> Participants { get; set; }
    }

    public class GroupMap : ClassMap<DisciplineParticipant>
    {
        public GroupMap()
        {
            Table("Groups");
            Id(x => x.Id, "Group_Id");
            HasMany(x => x.Participants);
            References(x => x.Discipline);
        }
    }
}
