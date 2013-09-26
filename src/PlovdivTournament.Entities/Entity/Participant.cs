using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Participant
    {
        public Participant() { }

        public Participant(string firstName, string middleName, string lastName, string eGN, string licenceNumber, Club club)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            EGN = eGN;
            LicenceNumber = licenceNumber;
            Club = club;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string EGN { get; set; }

        public virtual string LicenceNumber { get; set; }

        public virtual bool IsNewParticipant { get; set; }

        public virtual IList<CategoryMember> CategoryMembers { get; set; }

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
            HasManyToMany(x => x.CategoryMembers);
            Map(x => x.LicenceNumber);
            Map(x => x.IsNewParticipant);
        }
    }
}
