using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlovdivTournament.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PlovdivTournament.Web.Controllers" }
            );
            routes.MapRoute(
                name: "Club",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Club", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PlovdivTournament.Web.Controllers" }
            );
            routes.MapRoute(
                name: "RemoveMember",
                url: "{controller}/{action}/{memberId}",
                defaults: new { controller = "Club", action = "RemoveMember", memberId = "memberId" },
                namespaces: new string[] { "PlovdivTournament.Web.Controllers" }
            );
            routes.MapRoute(
                name: "GalleryDelete",
                url: "{controller}/{action}/{id}/{type}",
                defaults: new { controller = "Gallery", action = "RemoveMember", id = "id", type = "type" },
                namespaces: new string[] { "PlovdivTournament.Web.Controllers" }
            );
        }
    }
}