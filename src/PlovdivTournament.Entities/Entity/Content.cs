﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;

namespace PlovdivTournament.Entities.Entity
{
    public class Content
    {
        public Content() { }

        public Content(string page, string language, string pageContent)
        {
            Page = page;
            PageContent = pageContent;
            Language = language;
        }

        public virtual Guid Id { get; set; }

        public virtual string Page { get; set; }

        public virtual string PageContent { get; set; }

        public virtual string Language { get; set; }
    }

    public class ContentMap : ClassMap<Content>
    {
        public ContentMap()
        {
            Table("Content");
            Id(x => x.Id, "Content_Id");
            Map(x => x.Page, "Page");
            Map(x => x.PageContent, "Page_Content").Length(12000);
            Map(x => x.Language, "Language");
        }
    }
}