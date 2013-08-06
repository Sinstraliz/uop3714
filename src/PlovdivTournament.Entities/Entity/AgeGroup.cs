using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class AgeGroup
    {
        public AgeGroup() { }

        public virtual Guid Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual double MinimumAge { get; set; }

        public virtual double MaximumAge { get; set; }

        public virtual DisciplineRule Discipline { get; set; }
    }

    public class AgeGroupMap : ClassMap<AgeGroup>
    {
        public AgeGroupMap()
        {
            Table("Age_Group");
            Id(x => x.Id, "Age_Group_Id");
            Map(x => x.Name, "Name");
            Map(x => x.MinimumAge, "Minimum_Age");
            Map(x => x.MaximumAge, "Maximum_Age");
            References(x => x.Discipline, "Discipline_Id");
        }
    }
}