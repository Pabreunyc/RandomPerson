using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomPerson.Services;

namespace RandomPerson.Controllers
{

    internal class ParkingPermitsController
    {
        private readonly ParkingPermitsService PermitsService;

        public ParkingPermitsController()
        {
            PermitsService = new ParkingPermitsService();
            int queueLength = PermitsService.GetQueue();

            Console.WriteLine("Queue length: {0}", queueLength);
        }
    }

}
