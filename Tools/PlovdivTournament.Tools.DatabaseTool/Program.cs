﻿using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PlovdivTournament.Entities;
using PlovdivTournament.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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

                var admin = new User(adminId, "samodiva1998", "760508", "Admin", "Admin", "Admin", "Admin", "Admin", "Admin", true);
                var address = new Address("Admin", "Admin", "Admin", "Admin", "Admin", admin);
                admin.Address = address;
                var club = new Club("Samodiva", "Admin", admin);
                admin.Club = club;
                admin.IsAdmin = true;
                admin.IsActive = true;
                session.Save(admin);


                var masterAdmin = new User(Guid.NewGuid(), "Sinstraliz", "pr0st0passa", "Admin", "Admin", "Admin", "Admin", "Admin", "Admin", true);
                var masterAddress = new Address("Admin", "Admin", "Admin", "Admin", "Admin", masterAdmin);
                masterAdmin.Address = masterAddress;
                var masterClub = new Club("Admin", "Admin", masterAdmin);
                masterAdmin.Club = masterClub;
                masterAdmin.IsAdmin = true;
                masterAdmin.IsActive = true;
                session.Save(masterAdmin);

                session.Flush();

                session.Transaction.Commit();
            }
            sessionFactory.Close();
            Console.WriteLine("END :Inserting default entities");

        }
    }
}
