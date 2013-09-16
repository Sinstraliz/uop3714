using Castle.Windsor;
using PlovdivTournament.Web.Manage.Library.IdentityAndAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PlovdivTournament.Web.Manage
{
    public class Global : System.Web.HttpApplication
    {
        public static IWindsorContainer Container { get; private set; }
        public static SecurityManager SecurityManager { get { return Container.Resolve<SecurityManager>(); } }

        protected void Application_Start(object sender, EventArgs e)
        {

        }
    }
}