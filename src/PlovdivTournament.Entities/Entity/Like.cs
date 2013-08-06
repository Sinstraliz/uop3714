using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace PlovdivTournament.Entities.Entity
{
    public class Like
    {
        protected Like() { }

        public Like(Photo photo, User liker)
        {
            Photo = photo;
            Liker = liker;
        }

        public virtual Guid Id { get; protected set; }

        public virtual Photo Photo { get; protected set; }

        public virtual User Liker { get; protected set; }
    }
    public class LikeMap : ClassMap<Like>
    {
        public LikeMap()
        {
            Table("likes");
            Id(x => x.Id, "like_id");
            References(x => x.Photo, "photo_id");
            References(x => x.Liker, "liker_id");
        }
    }
}