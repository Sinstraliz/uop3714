using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class AgeGroup
    {
        public AgeGroup() { }

        public AgeGroup(string name, int minimumAge, int maximumAge, int allowedMinimumAge)
        {
            Name = name;
            MinimumAge = minimumAge;
            MaximumAge = maximumAge;
            AllowedMinimumAge = allowedMinimumAge;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string Name { get; set; }

        public virtual int MinimumAge { get; set; }

        public virtual int MaximumAge { get; set; }

        public virtual int AllowedMinimumAge { get; set; }
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
            Map(x => x.AllowedMinimumAge);
        }
    }
}