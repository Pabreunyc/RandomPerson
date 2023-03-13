using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPerson.Models
{
    /// <summary>
    ///   accessing tbl_web_parking_permit_generate_queue
    /// </summary>
    internal class ParkingPermitsQueue
    {
        public int QueueId { get; set; }
        public int OppId { get; set; }
        public int IsTemp { get; set; }

        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public string? RequestorEmail { get; set; }
        public string? QueueStatus { get; set; }
        public string? Filepath { get; set; }

        public DateTime Expiration { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateStartGeneration { get; set; }
        public DateTime DateGenerated { get; set; }

        public bool EmailSent { get; set; }
        public bool Processing { get; set; }

        public int QueueCount { get; set; }

    }
}
