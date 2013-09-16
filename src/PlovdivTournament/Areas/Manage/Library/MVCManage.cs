using Castle.Windsor;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlovdivTournament.Web.Manage.Library
{
    public class MVCManage
    {
        public static IWindsorContainer Container { get; set; }
        public static SecurityManager SecurityManager { get { return Container.Resolve<SecurityManager>(); } }
    }
}