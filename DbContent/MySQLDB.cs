using MySqlConnector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            //string connectionString = configuration.GetConfigValue(dbString);
            Connection = new MySqlConnection(dbConnectionString);
        }

        public MySqlDataReader GetMySqlReader(string query)
        {
            MySqlCommand command = MySqlCommand(query);
            Connection.Open();

            return command.ExecuteReader();
        }

        public MySqlDataReader GetMySqlReaderWithParameters(string query, JObject jObject, BaseObject dto)
        {
            Console.WriteLine("query=>" + query);
            MySqlCommand command = new MySqlCommand();
            command.Connection = Connection;
            command.CommandText = query;

            foreach (var item in jObject.OfType<JProperty>())
            {
                string key = item.Name;

                if ("int" == dto.getFieldType(key))
                {
                    if (jObject[key].Type != JTokenType.Null)
                    {
                        Console.WriteLine("Not Null Integer=>" + (int)jObject[key]);
                        command.Parameters.AddWithValue("@" + key, (int)jObject[key]);
                    }
                    else
                    {
                        //Console.WriteLine("Null Integer");
                        command.Parameters.AddWithValue("@" + key, DBNull.Value);
                    }
                    //command.Parameters.AddWithValue("@" + key, (DBNull.Value.Equals(jObject[key]) ? DBNull.Value : (int)jObject[key]));
                }
                else if ("string" == dto.getFieldType(key))
                {
                    if (jObject[key].Type != JTokenType.Null)
                    {
                        //Console.WriteLine("Not Null string");
                        command.Parameters.AddWithValue("@" + key, (string)jObject[key]);
                    }
                    else
                    {
                        //Console.WriteLine("Null string");
                        command.Parameters.AddWithValue("@" + key, DBNull.Value);
                    }

                }
                else if ("DateTime" == dto.getFieldType(key))
                {
                    if (jObject[key].Type != JTokenType.Null)
                    {
                        //Console.WriteLine("Not Null string");
                        command.Parameters.AddWithValue("@" + key, (DateTime)jObject[key]);
                    }
                    else
                    {
                        //Console.WriteLine("Null string");
                        command.Parameters.AddWithValue("@" + key, DBNull.Value);
                    }

                }
            }

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
