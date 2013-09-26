using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PlovdivTournament.Entities.Entity
{
    public class Tournament
    {
        public Tournament()
        {
            Disciplines = new List<Discipline>();
        }

        public Tournament(Guid id, string name, string place, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Place = place;
            StartDate = startDate;
            EndDate = endDate;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual string Place { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual IList<Discipline> Disciplines { get; set; }
    }

    public class TournamentMap : ClassMap<Tournament>
    {
        public TournamentMap()
        {
            Table("Tournaments");
            Id(x => x.Id, "Tournament_Id");
            Map(x => x.Name, "Name");
            Map(x => x.Place, "Place");
            Map(x => x.IsActive, "Active");
            Map(x => x.StartDate, "Start_Date");
            Map(x => x.EndDate, "End_Date");
            HasMany(x => x.Disciplines).Cascade.AllDeleteOrphan();
        }
    }
}