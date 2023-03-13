using Microsoft.VisualBasic;
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

        public MainLoop()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateInfo"></param>
        public void PrintTime(Object stateInfo)
        {
            Console.WriteLine(DateAndTime.Now);
        }
        /// <summary>
        ///   Get information about the current Main Loop
        /// </summary>
        /// <returns>string name & description</returns>

    }
}
