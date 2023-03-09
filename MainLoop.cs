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
        private int _counter = 0;
        public string name { get; set; }
        public string description { get; set; }

        public MainLoop(string? name, string? description)
        {
            this.name = name ?? "-Unknown-";
            this.description = description ?? string.Empty;
        }

        /// <summary>
        ///   Get information about the current Main Loop
        /// </summary>
        /// <returns>string name & description</returns>
        public string GetInfo() {
            Console.WriteLine("Getting info");
            Console.WriteLine("Locale:" + Globals.CODE_PREFIX);
            return $"{name} {description}";
        }
    }
}
