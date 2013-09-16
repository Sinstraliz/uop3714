using Castle.Windsor;
using PlovdivTournament.Web.Library.ControllerFactory;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using PlovdivTournament.Web.Library.Installers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using PlovdivTournament.Web.Manage.Library;

namespace PlovdivTournament.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public static IWindsorContainer Container { get; private set; }
        public static SecurityManager SecurityManager { get { return Container.Resolve<SecurityManager>(); } }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            MvcApplication.Container = new WindsorContainer();
            MVCManage.Container = Container;
            MvcApplication.Container.Install(new WebInstaller(Assembly.GetAssembly(typeof(MvcApplication)), Assembly.GetAssembly(typeof(PlovdivTournament.Web.Manage.Controllers.HomeController))));
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}