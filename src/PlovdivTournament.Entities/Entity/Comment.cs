using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace PlovdivTournament.Entities.Entity
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(Guid id, string text, DateTime dateCreated, User author, Photo photo)
        {
            Id = id;
            Text = text;
            DateCreated = dateCreated;
            Author = author;
            Photo = photo;
        }

        public virtual Guid Id { get; protected set; }

        public virtual string Text { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual User Author { get; protected set; }

        public virtual Photo Photo { get; protected set; }
    }

    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Table("comments");
            Id(x => x.Id, "comment_id");
            Map(x => x.Text, "text").Length(4000);
            Map(x => x.DateCreated, "date_created");
            References(x => x.Author, "author_id");
            References(x => x.Photo, "photo_id");
        }
    }
}