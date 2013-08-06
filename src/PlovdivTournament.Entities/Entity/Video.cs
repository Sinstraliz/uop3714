using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Video
    {
        protected Video()
        {
            Likes = new List<Like>();
            Comments = new List<Comment>();
        }

        public Video(Guid id, string url, string title, string description, User owner, DateTime dateCreated, string category, bool enableComments)
        {
            Id = id;
            Url = url;
            Title = title;
            Description = description;
            Owner = owner;
            DateCreated = dateCreated;
            Likes = new List<Like>();
            Category = category;
            EnableComments = enableComments;
        }

        public virtual Guid Id { get; set; }

        public virtual string Url { get; set; }

        public virtual User Owner { get; protected set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual IList<Like> Likes { get; set; }

        public virtual IList<Comment> Comments { get; protected set; }

        public virtual bool EnableComments { get; set; }

        public virtual string Category { get; set; }
    }

    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Table("Videos");
            Id(x => x.Id, "Video_Id").GeneratedBy.Assigned();
            Map(x => x.DateCreated, "Date_Created");
            Map(x => x.Url, "Url");
            References(x => x.Owner, "Owner_Id");
            Map(x => x.Title, "Title");
            Map(x => x.Description, "Description").Length(4001);
            HasMany(x => x.Likes).Cascade.AllDeleteOrphan();
            HasMany(x => x.Comments).Cascade.AllDeleteOrphan();
            Map(x => x.Category, "Category");
            Map(x => x.EnableComments);
        }
    }
}