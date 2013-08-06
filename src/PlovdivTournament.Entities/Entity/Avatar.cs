using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace PlovdivTournament.Entities.Entity
{
    public class Avatar : Image
    {
        public static Guid DefaultAvatarId = Guid.Parse("60022BBF-F078-478F-8372-898E4B6CA4B9");

        protected Avatar() { }

        public Avatar(Guid id, byte[] content, User owner, DateTime dateCreated, string contentType)
        {
            Id = id;
            Content = content;
            Owner = owner;
            DateCreated = dateCreated;
            ContentType = contentType;
        }
    }

    public class AvatarMap : SubclassMap<Avatar>
    {
        public AvatarMap()
        {
            DiscriminatorValue(typeof(Avatar).Name);
        }
    }
}
