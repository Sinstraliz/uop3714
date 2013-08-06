using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Photo : Image
    {
        protected Photo()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }

        public Photo(Guid id, byte[] content, string title, string description, User owner, DateTime dateCreated, string contentType, string category, bool enableComments)
        {
            Id = id;
            Content = content;
            Title = title;
            Description = description;
            Owner = owner;
            DateCreated = dateCreated;
            ContentType = contentType;
            Likes = new List<Like>();
            Category = category;
            EnableComments = enableComments;
        }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Like> Likes { get; set; }

        public virtual IList<Comment> Comments { get; protected set; }

        public virtual bool EnableComments { get; set; }

        public virtual string Category { get; set; }
    }

    public class PhotoMap : SubclassMap<Photo>
    {
        public PhotoMap()
        {
            Table("Photos");
            Map(x => x.Title, "Title");
            Map(x => x.Description, "Description").Length(4001);
            HasMany(x => x.Likes).Cascade.AllDeleteOrphan();
            HasMany(x => x.Comments).Cascade.AllDeleteOrphan();
            Map(x => x.Category, "Category");
            DiscriminatorValue(typeof(Photo).Name);
            Map(x => x.EnableComments);
        }
    }
}