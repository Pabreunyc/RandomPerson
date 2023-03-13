// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RandomPerson.DbContent;
using RandomPerson.Models;

namespace RandomPerson
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<ParkingPermitsQueue> data = new List<ParkingPermitsQueue>();
            MainLoop ml = new MainLoop();

            try
            {
                MySqlDb mySqlDb = new MySqlDb("MySqlOnUbbyConnectionString");
                var res = mySqlDb.GetMySqlReader("SELECT * FROM olmsted_SAHD_MDB.tbl_web_parking_permit_generate_queue ORDER BY queue_id DESC;");

                int numFields = res.FieldCount;
                Console.WriteLine("Field count: {0}", numFields);
                Console.WriteLine("===================================");

                //ParkingPermitsQueue pq = new ParkingPermitsQueue();
                while (res.Read())
                {
                    //object[] objs = new object[numFields];
                    //res.GetValues(objs);
                    //data.Add(objs);
                    //Console.WriteLine(objs[2].ToString());

                    //Console.WriteLine(res.GetFieldType(0));
                    //Console.WriteLine(res.GetInt32("queue_id") + "::" + res.GetString(2));                    
                    //Environment.NewLine
                    ParkingPermitsQueue pq = new ParkingPermitsQueue
                    {
                        QueueId = res.GetInt32("queue_id"),
                        Fullname = res.GetString("emp_full_name").ToString(),
                        Email = res.GetString("emp_email").ToString(),
                        DateRequested = res.GetDateTime("date_requested"),
                        Processing = res.GetBoolean("processing")
                    };
                    data.Add(pq);
                }
                res.Close();

                Console.WriteLine("===========");
                Console.WriteLine("Records Found: " + data.Count);

            }
            catch (Exception ex)
            {
                Console.Beep();
                Console.Title = "DB Exception!";
                Console.WriteLine(ex.ToString());
                Environment.Exit(1);
            }

            Timer timer1 = new Timer(ml.PrintTime, null, 1000, 1000);
            Console.WriteLine("Running timed event. Enter to quit");
            //timer1.Dispose();
            
        }

        
        public static int Factorial(int n)
        {
            if( n < 0 || n > 20 )
                throw new ArgumentOutOfRangeException(nameof(n),
                      "The valid range is between 0 and 20.");

            if (n == 1 || n == 0)
                return 1;

            return n * Factorial(n - 1);
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