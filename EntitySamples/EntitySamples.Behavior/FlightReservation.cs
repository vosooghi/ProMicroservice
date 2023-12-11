using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySamples.Behavior
{
    public class FlightReservation
    {
        public Guid Id { get; set; }
        public  FlightDate FlightDate { get; private set; }
        public FlightReservation(Guid id, FlightDate flightDate)
        {
            
            Id = id;
            FlightDate = flightDate;

        }
    }
}
