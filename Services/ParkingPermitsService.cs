using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPerson.Services
{
    using DbContent;
    using Models;
    /// <summary>
    /// Implements service for parking permi
    /// </summary>
    internal class ParkingPermitsService
    {
        public ParkingPermitsService() {
            Console.WriteLine(">>> ParkingPermitsService <<<");
            _db = new MySqlDb("MySqlOnUbbyConnectionString");
        }

        /// <summary>
        /// Get current queue
        /// </summary>
        /// <returns>int num of records</returns>
        public int GetQueue()
        {
            Console.WriteLine("**");
            try
            {
                //MySqlDb mySqlDb = new MySqlDb("MySqlOnUbbyConnectionString");
                var res = _db.GetMySqlReader(SqlGetCurrentQueueAll);
                int numFields = res.FieldCount;
                //                         Email = res.GetString("emp_email").ToString(),
                while (res.Read() ) 
                {
                    ParkingPermitsQueue pq = new ParkingPermitsQueue
                    {
                        QueueId = res.GetInt32("queue_id"),
                        Fullname = res.GetString("emp_full_name").ToString(),

                        DateRequested = res.GetDateTime("date_requested"),
                        Processing = res.GetBoolean("processing")
                    };
                    this.ppq.Add(pq);
                }

                res.Close();
                return ppq.Count;
            }
            catch (Exception ex)
            {
                Console.Beep();
                Console.Title = "DB Exception!";
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public bool RemoveQueueItem(int id)
        {
            //int i = ppq.FindIndex
            return true;
        }
        /// <summary>
        /// Get ParkingQueue item by QueueId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ParkingPermitsQueue GetQueueItem(int id)
        {
            Console.WriteLine($"GetQueueItem: '{id}'");

            ParkingPermitsQueue p = ppq.Find(p =>
            {
                Console.Write(p.QueueId + "::");
                return p.QueueId.Equals(id);
            });
            Console.WriteLine("::" + p.Fullname);
            return p;
        }
        
        /// <summary>
        /// Writes current queue to console
        /// </summary>
        public void ListQueue()
        {
            foreach(ParkingPermitsQueue p in ppq)
            {
                Console.WriteLine($"{p.QueueId}: {p.Fullname}");
            }
        }
        public int GeQueueLength()
        {
            return ppq.Count();
        }

        // ====================================================================
        private List<ParkingPermitsQueue> ppq = new List<ParkingPermitsQueue>();
        private MySqlDb _db;

        private readonly static string SqlGetCurrentQueueAll = "SELECT * FROM olmsted_SAHD_MDB.tbl_web_parking_permit_generate_queue ORDER BY queue_id DESC;";
        private readonly static string SqlGetCurrentQueue = "SELECT * FROM olmsted_SAHD_MDB.tbl_web_parking_permit_generate_queue WHERE queue_status is NULL AND processing = 0;";
    }

    internal class ParkingPermitsServiceSqlStatments
    {
        
    }
}
