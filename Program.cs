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

            MySqlDb mySqlDb = new MySqlDb("MySqlOnUbbyConnectionString");
            var res = mySqlDb.GetMySqlReader("select * from olmsted_SAHD_MDB.tbl_web_parking_permit_generate_queue order by queue_id LIMIT 5 DESC;");
            Console.WriteLine(res.ToString());
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
    }
}