using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Photo : Image
    {
        protected Photo()
        {

        }

        public Photo(Guid id, byte[] content, string title, string description, User owner, DateTime dateCreated, string contentType, string category)
        {
            Id = id;
            Content = content;
            Title = title;
            Description = description;
            Owner = owner;
            DateCreated = dateCreated;
            ContentType = contentType;
            Category = category;
        }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual string Category { get; set; }
    }

    public class PhotoMap : SubclassMap<Photo>
    {
        public PhotoMap()
        {
            Table("Photos");
            Map(x => x.Title, "Title");
            Map(x => x.Description, "Description").Length(4001);
            Map(x => x.Category, "Category");
            DiscriminatorValue(typeof(Photo).Name);
        }
    }
}