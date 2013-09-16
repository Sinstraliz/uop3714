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
                "Manage_Home",
                "Manage",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                 namespaces: new string[] { "PlovdivTournament.Web.Manage.Controllers" }
            );

            context.MapRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                   namespaces: new string[] { "PlovdivTournament.Web.Manage.Controllers" }
            );
        }
    }
}