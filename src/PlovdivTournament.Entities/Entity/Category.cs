using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Category
    {
        public Category() { }

        public Category(string categoryName, List<AgeGroup> ageGroups, int minNumberOfParticipants, int maxNumberOfParticipants)
        {
            CategoryName = categoryName;
            AgeGroups = ageGroups;
            MinNumberOfParticipants = minNumberOfParticipants;
            MaxNumberOfParticipants = maxNumberOfParticipants;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string CategoryName { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual IList<AgeGroup> AgeGroups { get; set; }

        public virtual int MinNumberOfParticipants { get; set; }

        public virtual int MaxNumberOfParticipants { get; set; }

        public virtual IList<CategoryMember> CategoryMembers { get; set; }
    }

    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x => x.Id, "Category_Id");
            References(x => x.Discipline);
            Map(x => x.MinNumberOfParticipants, "Min_Number_Of_Participants");
            Map(x => x.MaxNumberOfParticipants, "Max_Number_Of_Participants");
            Map(x => x.CategoryName, "Category_Name");
            HasMany(x => x.CategoryMembers).Cascade.AllDeleteOrphan();
            HasMany(x => x.AgeGroups).Cascade.AllDeleteOrphan();
        }
    }
}
