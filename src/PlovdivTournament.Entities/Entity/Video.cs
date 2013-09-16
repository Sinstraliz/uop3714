using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class Video
    {
        protected Video()
        {

        }

        public Video(Guid id, string url, string title, string description, User owner, DateTime dateCreated, string category, byte[] coverContent, string coverContentType)
        {
            Id = id;
            Url = url;
            Title = title;
            Description = description;
            Owner = owner;
            DateCreated = dateCreated;
            Category = category;
            CoverContentType = coverContentType;
            CoverContent = coverContent;
        }

        public virtual Guid Id { get; set; }

        public virtual string Url { get; set; }

        public virtual User Owner { get; protected set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual string Category { get; set; }

        public virtual string CoverContentType { get; set; }

        public virtual byte[] CoverContent { get; set; }
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
            Map(x => x.Category, "Category");
            Map(x => x.CoverContent, "Cover_Content").CustomSqlType("varbinary(MAX)").Length(3000000).LazyLoad();
            Map(x => x.CoverContentType, "Cover_Content_Type");
            DiscriminateSubClassesOnColumn("Image_Type");
        }
    }
}