using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class Participant
    {
        public Participant() { }

        public virtual Guid Id { get; protected set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string EGN { get; set; }

        public virtual string LicenceNumber { get; set; }

        public virtual bool IsNewParticipant { get; set; }

        public virtual Club Club { get; set; }
    }
    public class ParticipantMap : ClassMap<Participant>
    {
        public ParticipantMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.MiddleName);
            Map(x => x.LastName);
            Map(x => x.EGN);
            References(x => x.Club);
            Map(x => x.LicenceNumber);
            Map(x => x.IsNewParticipant);
        }
    }
}
