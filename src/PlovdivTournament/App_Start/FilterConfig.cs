﻿using PlovdivTournament.Web.Library.Attributes;
using System.Web.Mvc;

namespace PlovdivTournament.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionHandlingAttribute());
        }
    }
}