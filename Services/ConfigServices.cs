using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPerson.Services
{
    internal class ConfigServices
    {
        public ConfigServices()
        {
            Console.WriteLine("Buffer:" + Globals.BUFFER_SIZE);
            // EnvironmentVariableTarget 
            // https://stackoverflow.com/questions/65110479/how-to-get-values-from-appsettings-json-in-a-console-application-using-net-core?noredirect=1&lq=1
            //var x = ConfigurationManager.AppSettings.Get("connectionStrings");
            //var x = ConfigurationManager.ConnectionStrings["MySqlOnUbbyConnectionString"];
            var x = ConfigurationManager.ConnectionStrings["MySqlOnUbbyConnectionString"].ConnectionString;
            var smtp = ConfigurationManager.GetSection("smtp");

            Console.WriteLine("SMTP:" + smtp);
            Console.WriteLine("Type:" + x.GetType());
            Console.WriteLine("DbConnectionString:" + x);

            //Console.WriteLine("SMTP:" + smtp);
            //Console.BackgroundColor = ConsoleColor.Green;
            //Environment.UserInteractive
            IDictionary env = Environment.GetEnvironmentVariables();
            //Dictionary<string, string> ev = Environment.GetEnvironmentVariables();
            /*
            foreach ( DictionaryEntry p in  ev)
            {
                Console.WriteLine("    {0} = {1}", p.Key, p.Value);
            }
            */
            Console.WriteLine("env:FrameworkVersion32: " + env["FrameworkVersion32"]);
            Console.WriteLine("env:APS.Net" + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") );
            Console.WriteLine("env:DEV_ENVIRONMENT" + Environment.GetEnvironmentVariable("DEV_ENVIRONMENT") );
            //Console.BackgroundColor = ConsoleColor.White;

            string sAttr = ConfigurationManager.AppSettings.Get("SMTP") ?? "";
            Console.WriteLine("SMTP:" + sAttr);
        }
    }
}
