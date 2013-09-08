using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace PlovdivTournament.Entities.Entity
{
    public class TournamentInfo
    {
        public TournamentInfo() { }

        virtual public Guid Id { get; set; }

        virtual public Guid TournamentId { get; set; }

        virtual public int LanguageLCID { get; set; }

        virtual public string Evaluation { get; set; }

        virtual public string Fest { get; set; }

        virtual public string Program { get; set; }

        virtual public string Referees { get; set; }

        virtual public string Taxes { get; set; }
    }

    public class TournamentInfoMap : ClassMap<TournamentInfo>
    {

        public TournamentInfoMap()
        {
            Table("tournament_info");
            Id(x => x.Id);
            Map(x => x.TournamentId);
            Map(x => x.LanguageLCID);
            Map(x => x.Evaluation).Length(4000);
            Map(x => x.Fest).Length(4000);
            Map(x => x.Program).Length(4000);
            Map(x => x.Referees).Length(4000);
            Map(x => x.Taxes).Length(4000);
        }
    }
}
