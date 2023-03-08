// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RandomPerson
{
    class Program
    {
        static async Task Main(string[] args)
        {
            MainLoop ml = new MainLoop("Glass", "Fixed main loop");

            var client = new HttpClient();
            var responseString = await client.GetStringAsync("https://randomuser.me/api/?results=5");
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

            Console.WriteLine(ml.GetInfo());

            try
            {
                Console.WriteLine(Environment.NewLine + Factorial(8));
            }
            catch( Exception ex)
            {
                Console.Beep();
                Console.Title = "Error!";
                Console.WriteLine("Error:" + ex.ToString());
                Environment.Exit(1);
            }

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
    }
}