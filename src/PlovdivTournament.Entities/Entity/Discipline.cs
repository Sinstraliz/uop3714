
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
namespace PlovdivTournament.Entities.Entity
{
    public class Discipline
    {
        public Discipline() { }

        public virtual Guid Id { get; protected set; }

        public virtual DisciplineRule Rule { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual IList<DisciplineParticipant> Categories { get; set; }
    }
       

    public class DisciplineMap : ClassMap<Discipline>
    {
        public DisciplineMap()
        {
            Table("Disciplines");
            Id(x => x.Id, "Discipline_Id");
            References(x => x.Tournament, "Tournament_Id");
            HasMany(x => x.Categories);
        }
    }
}