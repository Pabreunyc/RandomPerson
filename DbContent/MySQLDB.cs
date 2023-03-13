﻿using MySqlConnector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPerson.DbContent
{
    internal class MySqlDb
    {
        public MySqlConnection Connection { get; }
        public MySqlDb(string dbConnectionString)
        {
            dbConnectionString = dbConnectionString.Trim();
            Console.WriteLine("MySqlDb: " + dbConnectionString);
            string connectionString = ConfigurationManager.ConnectionStrings[dbConnectionString].ConnectionString;
            //string connectionString = ConfigurationManager.ConnectionStrings[dbConnectionString];

            Console.WriteLine("DB Connection String:" + connectionString);
            Connection = new MySqlConnection(connectionString);
        }

        public MySqlDataReader GetMySqlReader(string query)
        {
            query = query.Trim();            
            MySqlCommand command = MySqlCommand(query);
            Connection.Open();
            return command.ExecuteReader();
        }
        

        public void Close()
        {
            Connection?.Close();
        }

        private MySqlCommand MySqlCommand(string query)
        {

            return new MySqlCommand(query, Connection);
        }

    }

}
