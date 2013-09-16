
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
namespace PlovdivTournament.Entities.Entity
{
    public class Discipline
    {
        public Discipline() { }

        public Discipline(string disciplineName, Tournament tournament)
        {
            DisciplineName = disciplineName;
            Tournament = tournament;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string DisciplineName { get; set; }

        public virtual IList<DisciplineRule> Rules { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual IList<Category> Categories { get; set; }
    }


    public class DisciplineMap : ClassMap<Discipline>
    {
        public DisciplineMap()
        {
            Table("Disciplines");
            Id(x => x.Id, "Discipline_Id");
            References(x => x.Tournament, "Tournament_Id");
            Map(x => x.DisciplineName, "Discipline_Name");
            HasMany(x => x.Rules);
            HasMany(x => x.Categories);
        }
    }
}