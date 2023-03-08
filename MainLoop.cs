using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPerson
{
    public class MainLoop
    {
        private int _id;
        public string name { get; set; }
        public string description { get; set; }

        public MainLoop(string? name, string? description)
        {
        }

        public string GetInfo() {
            Console.WriteLine("Getting info");
            return $"{name} {description}";
        }
    }
}
