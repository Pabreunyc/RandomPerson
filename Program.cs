// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RandomPerson.DbContent;

namespace RandomPerson
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<object>    data = new List<object>();

            MainLoop ml = new MainLoop("Glass", "A very fragile man");
            
            try
            {
                Console.WriteLine(Environment.NewLine + "Fac(8) = " + Factorial(8));
            }
            catch( Exception ex)
            {
                Console.Beep();
                Console.Title = "Error!";
                Console.WriteLine("Error:" + ex.ToString());
                Environment.Exit(1);
            }

            try
            {
                MySqlDb mySqlDb = new MySqlDb("MySqlOnUbbyHomeConnectionString");
                var res = mySqlDb.GetMySqlReader("SELECT * FROM olmsted_SAHD_MDB.tbl_web_parking_permit_generate_queue ORDER BY queue_id DESC;");

                //res.Read();
                //object[] objs = new object[20];
                int numFields = res.FieldCount;
                //Console.WriteLine("numFields: {numFields}");
                Console.WriteLine("Field count: {0}", numFields);
                Console.WriteLine("===================================");

                while( res.Read() )
                {
                    object[] objs = new object[numFields];
                    res.GetValues(objs);
                    data.Add(objs);
                    Console.WriteLine(objs[2].ToString());
                }
                res.Close();

                Console.WriteLine("Records Found: " + data.Count);
                //Console.WriteLine(data[0]);
/*
                foreach (object o in data)
                {
                    Console.WriteLine(o.ToString());
                }
*/
            } catch( Exception ex )
            {
                Console.Beep();
                Console.Title = "DB Exception!";
                Console.WriteLine(ex.ToString());   
                Environment.Exit(1);
            }
        }

        private int StartUp(string[] cmdLine)
        {

            return 0;
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