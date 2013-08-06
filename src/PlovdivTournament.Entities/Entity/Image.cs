using FluentNHibernate.Mapping;
using System;

namespace PlovdivTournament.Entities.Entity
{
    public class Image
    {
        public Image() { }

        public virtual Guid Id { get; set; }

        public virtual byte[] Content { get; set; }

        public virtual User Owner { get; protected set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual string ContentType { get; set; }
    }

    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Id(x => x.Id, "Photo_id").GeneratedBy.Assigned();
            Map(x => x.Content, "Content").CustomSqlType("varbinary(MAX)").Length(3000000).LazyLoad();
            Map(x => x.DateCreated, "Date_Created");
            Map(x => x.ContentType, "Content_Type");
            References(x => x.Owner, "Owner_Id");
            DiscriminateSubClassesOnColumn("Image_Type");
        }
    }
}