using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class DisciplineRule
    {
        public DisciplineRule() { }

        public virtual Guid Id { get; protected set; }
    }

    public class DisciplineRuleMap : ClassMap<DisciplineRule>
    {
        public DisciplineRuleMap()
        {
            Table("DisciplineRules");
            Id(x => x.Id, "Discipline_Rule_Id");
        }
    }
}
