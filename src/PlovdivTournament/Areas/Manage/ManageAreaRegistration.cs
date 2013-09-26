using System.Web.Mvc;

namespace PlovdivTournament.Web.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Manage_Home",
                url: "Manage",
                defaults: new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                namespaces: new string[] { "PlovdivTournament.Web.Manage.Controllers" }
            );

            context.MapRoute(
                name: "Manage_default",
                url: "Manage/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "PlovdivTournament.Web.Manage.Controllers" }
            );
        }
    }
}