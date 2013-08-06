using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class DisciplineRule
    {
        public virtual Guid Id { get; protected set; }

        public virtual string Genre { get; set; }

        public virtual int MinNumberOfParticipants { get; set; }

        public virtual int MaxNumberOfParticipants { get; set; }

        public virtual string DisciplineName { get; set; }

        public virtual AgeGroup AgeGroup { get; set; }
    }

    public class DisciplineRuleMap : ClassMap<DisciplineRule>
    {
        public DisciplineRuleMap()
        {
            Table("DisciplineRules");
            Id(x => x.Id, "Discipline_Rule_Id");
            Map(x => x.Genre, "Genre");
            Map(x => x.DisciplineName, "Discipline_Name");
            Map(x => x.MinNumberOfParticipants, "Min_Number_Of_Participants");
            Map(x => x.MaxNumberOfParticipants, "Max_Number_Of_Participants");
            References(x => x.AgeGroup, "Age_Group_Id");
        }
    }
}
