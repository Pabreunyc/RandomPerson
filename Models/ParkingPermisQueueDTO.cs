using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPerson.Models
{
    internal class ParkingPermisQueueDTO
    {
        private List<ParkingPermitsQueue> _data;

        ParkingPermisQueueDTO()
        {
            _data= new List<ParkingPermitsQueue>();
        }
        public bool AddRow(DbDataReader rdr)
        {

            return true;
        }
    }
}
