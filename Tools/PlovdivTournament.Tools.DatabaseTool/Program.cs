using System;
using System.Configuration;
using System.Data.SqlClient;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using PlovdivTournament.Entities;
using PlovdivTournament.Entities.Entity;

namespace MyPhoto.Tools.DatabaseTool
{
    class Program
    {
        static Guid adminId = new Guid("4F59C3B3-D170-4DC9-B402-6A3612D50FEA");

        static void Main(string[] args)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = ConfigurationManager.AppSettings["Hostname"];
            builder.UserID = ConfigurationManager.AppSettings["Username"];
            builder.Password = ConfigurationManager.AppSettings["Password"];
            builder.InitialCatalog = ConfigurationManager.AppSettings["DatabaseName"];

            DatabaseManager.DropTablesWithoutEventStore(builder.ToString());

            var nHibernateConfig = new NHibernate.Cfg.Configuration();
            nHibernateConfig.SetProperty(NHibernate.Cfg.Environment.ConnectionString, builder.ToString());

            var nHibernateConfigFluent =
            Fluently.Configure(nHibernateConfig).Mappings(cfg =>
            {
                cfg.FluentMappings.AddFromAssemblyOf<IHaveEntities>();
            }).ExposeConfiguration(cfg => new SchemaExport(cfg)
                                              .Execute(false, true, false))
          .BuildConfiguration();
            Console.WriteLine("Database Built");
            Console.WriteLine("Inserting default entities");
            var sessionFactory = nHibernateConfigFluent.BuildSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                session.BeginTransaction();
                //Insert Default Entities in the DB From her

                var admin = new User(adminId, "admin", "123qwe", "noreply@MyPhoto.com", "ASD", "ASD", "ASD", "ASD", "ASD", "ASD");
                session.Save(admin);
                session.Flush();
                admin.IsAdmin = true;


                session.Transaction.Commit();
            }
            sessionFactory.Close();
            Console.WriteLine("END :Inserting default entities");

        }
    }
}
