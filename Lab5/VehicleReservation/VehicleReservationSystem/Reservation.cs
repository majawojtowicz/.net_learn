using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleReservationSystem
{
    public class Reservation
    {
        public int VehicleId { get; set; }
        public string Customer { get; set; }
        public DateTime ReservationDate { get; set; }

        public Reservation(int vehicleId, string customer)
        {
            VehicleId = vehicleId;
            Customer = customer;
            ReservationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Reservation for {VehicleId} for {Customer} on {ReservationDate}";
        }
    }
}
