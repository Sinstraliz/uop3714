using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MyPhoto.Tools.DatabaseTool
{
    public static class DatabaseManager
    {
        private const string CreateDatabaseQuery = "USE master CREATE DATABASE {0} ON (NAME = {0}, FILENAME ='{1}{0}.mdf') LOG ON (NAME = {0}_log, FILENAME ='{1}{0}.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS";
        private const string IsDatabaseExistsQuery = "USE master SELECT name FROM master.dbo.sysdatabases WHERE name = N'{0}'";
        private const string DeleteDatabaseQuery = "USE master ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [{0}]";
        private const string DeleteDatabaseTables = @"use {0} begin tran DECLARE @TableName NVARCHAR(MAX) DECLARE @ConstraintName NVARCHAR(MAX) DECLARE DisableConstraints CURSOR FOR SELECT name as TABLE_NAME FROM sys.tables a WHERE name != 'Commits' and name != 'Snapshots'  OPEN DisableConstraints  FETCH NEXT FROM DisableConstraints INTO @TableName WHILE @@FETCH_STATUS = 0 BEGIN   EXEC('ALTER TABLE [' + @TableName + '] NOCHECK CONSTRAINT all')  FETCH NEXT FROM DisableConstraints INTO @TableName END print 'Done Disable Constraints' CLOSE DisableConstraints DEALLOCATE DisableConstraints DECLARE Constraints CURSOR FOR SELECT  TABLE_NAME, CONSTRAINT_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE TABLE_NAME != 'Commits' and TABLE_NAME != 'Snapshots' OPEN Constraints FETCH NEXT FROM Constraints INTO @TableName, @ConstraintName WHILE @@FETCH_STATUS = 0 BEGIN EXEC('ALTER TABLE [' + @TableName + '] NOCHECK CONSTRAINT all') 		 if exists (SELECT	CONSTRAINT_NAME 	FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS 	WHERE CONSTRAINT_NAME = @ConstraintName 	and TABLE_NAME = @TableName)	BEGIN 		EXEC('ALTER TABLE [' + @TableName + '] DROP CONSTRAINT [' + @ConstraintName + ']')	END  FETCH NEXT FROM Constraints INTO @TableName, @ConstraintName END  CLOSE Constraints DEALLOCATE Constraints  print 'Done Constraints' DECLARE Tables CURSOR FOR  SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_NAME != 'Snapshots' and TABLE_NAME != 'Commits')  OPEN Tables FETCH NEXT FROM Tables INTO @TableName WHILE @@FETCH_STATUS = 0 BEGIN EXEC('DROP TABLE [' + @TableName + ']') FETCH NEXT FROM Tables INTO @TableName END CLOSE Tables DEALLOCATE Tables print 'Done Tables' commit tran";
        private const string defaultDataFilePath = @"D:\SQL2008\";

        public static void CreateDatabase(string connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string dbName = builder.InitialCatalog;
            builder.InitialCatalog = "master";

            if (Exists(dbName, builder.ToString()))
                throw new Exception(String.Format("Database '{0}' exists.", dbName));


            SqlConnection conn = new SqlConnection(builder.ToString());

            try
            {
                conn.Open();
                var command = String.Format(CreateDatabaseQuery, dbName, defaultDataFilePath);
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }

        public static void DeleteDatabase(string connectionString)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string dbName = builder.InitialCatalog;
            builder.InitialCatalog = "master";
            if (!Exists(dbName, builder.ToString()))
                return;


            SqlConnection conn = new SqlConnection(builder.ToString());

            try
            {
                conn.Open();
                var command = String.Format(DeleteDatabaseQuery, dbName);
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static void DropTablesWithoutEventStore(string connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string dbName = builder.InitialCatalog;
            builder.InitialCatalog = "master";
            if (!Exists(dbName, builder.ToString()))
                return;

            SqlConnection conn = new SqlConnection(builder.ToString());

            try
            {
                conn.Open();
                var command = String.Format(DeleteDatabaseTables, dbName);

                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool Exists(string databaseName, string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();

                string query = String.Format(IsDatabaseExistsQuery, databaseName);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                using (dr)
                {
                    return dr.HasRows;
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
