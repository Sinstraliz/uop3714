using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using NHibernate;
using PlovdivTournament.Entities;
using PlovdivTournament.Web.Library.IdentityAndAccess;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PlovdivTournament.Web.Library.Installers
{
    public class WebInstaller : IWindsorInstaller
    {
        IWindsorContainer container;
        Assembly[] assembmliesContaingingControllesrs;
        public WebInstaller(params Assembly[] assembmliesContaingingControllesrs)
        {
            this.assembmliesContaingingControllesrs = assembmliesContaingingControllesrs;
        }
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.container = container;
            foreach (Assembly asm in assembmliesContaingingControllesrs)
            {
                var controllers = asm.GetTypes().Where(x => typeof(Controller).IsAssignableFrom(x));
                foreach (Type controller in controllers)
                {
                    container.Register(Component.For(controller).LifeStyle.Transient);
                }
            }
            container.Register(
                Component.For<SecurityManager>().LifeStyle.PerWebRequest,
                  Component.For<ISessionFactory>().UsingFactoryMethod(x => BuildSessionFactory()).LifeStyle.Singleton,
                   Component.For<ISession>()
                       .UsingFactoryMethod(x => OpenSession()).LifeStyle.PerWebRequest
                       .OnDestroy(x => CloseSession(x))
                       );
        }

        private ISessionFactory BuildSessionFactory()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = ConfigurationManager.AppSettings["Hostname"],
                UserID = ConfigurationManager.AppSettings["Username"],
                Password = ConfigurationManager.AppSettings["Password"],
                InitialCatalog = ConfigurationManager.AppSettings["DatabaseName"]
            };

            var nHibernateConfig = new NHibernate.Cfg.Configuration();
            nHibernateConfig.SetProperty(NHibernate.Cfg.Environment.ConnectionString, builder.ToString());

            var nHibernateConfigFluent =
            Fluently.Configure(nHibernateConfig).Mappings(cfg =>
            {
                cfg.FluentMappings.AddFromAssemblyOf<IHaveEntities>();
            }).BuildConfiguration();
            return nHibernateConfigFluent.BuildSessionFactory();
        }

        private ISession OpenSession()
        {
            var sessionFactory = container.Resolve<ISessionFactory>();

            ISession session = sessionFactory.OpenSession();
            session.BeginTransaction();
            return session;
        }

        private void CloseSession(ISession session)
        {
            if (session == null)
                return;

            MvcApplication.Container.Release(session);

            if (!session.Transaction.IsActive)
                return;

            if (HttpContext.Current.AllErrors != null)
                session.Transaction.Rollback();
            else
                session.Transaction.Commit();
        }
    }
}