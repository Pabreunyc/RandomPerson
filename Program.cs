﻿// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace RandomPerson
{
    using DbContent;
    using Models;
    using Services;
    
    class Program
    {
        static async Task Main(string[] args)
        {
            MainLoop ml = new MainLoop();
            ConfigServices configServices = new ConfigServices();
            Console.WriteLine("Code Prefix:" + Globals.CODE_PREFIX);

            // https://stackoverflow.com/questions/65110479/how-to-get-values-from-appsettings-json-in-a-console-application-using-net-core?noredirect=1&lq=1
            //var x = ConfigurationManager.AppSettings.Get("connectionStrings");
            //var x = ConfigurationManager.ConnectionStrings["MySqlOnUbbyConnectionString"];
            //Console.WriteLine("Type:" + x.GetType());
            //Console.WriteLine("x:" + x);


            //string sAttr = ConfigurationManager.AppSettings.Get("Key0") ?? "";
            //Console.WriteLine(sAttr);

            /*
                        ParkingPermitsService permitsService = new ParkingPermitsService();
                        Console.WriteLine("*");
                        int ql = permitsService.GetQueue();
                        Console.WriteLine("Queue Length:{0}", ql);
                        Console.WriteLine("Confirm Length: {0}", permitsService.GeQueueLength());

                        ParkingPermitsQueue p1 = permitsService.GetQueueItem(186);
                        Console.WriteLine("Found:" + p1.Fullname);
            */

            Console.ResetColor();
        }

        
        
        private void foo()
        {
            /*
             var client = new HttpClient();
            var responseString = await client.GetStringAsync(");
            //Console.WriteLine(responseString);
            var responseJson = JObject.Parse(responseString);
            var results = responseJson["results"];
            foreach (var result in results)
            {
                var firstName = (string)result["name"]["first"];
                var lastName = (string)result["name"]["last"];
                var email = (string)result["email"];
                Console.WriteLine($"{firstName} {lastName}: {email}");           
            }
           */
        }

        private void goo(string message)
        {
            ArgumentNullException.ThrowIfNull(nameof(goo));
            Console.Write(value: "Goo says: '{message}");

        }
    }
}