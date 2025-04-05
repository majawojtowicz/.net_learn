using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleReservationSystem
{
    public class RentalCompany
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private List<Reservation> reservations = new List<Reservation>();

        public event Action<string> OnNewReservation;


        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }
        public void ReserveVehicle(int vehicleId, string customer)
        {
            var vehicle = vehicles.FirstOrDefault(v=>v.Id == vehicleId);
            if (vehicle == null)
            {
                Console.WriteLine("Not found");
                return;
            }

            if (vehicle.IsAvailable)
            {
                if (vehicle is IReservable reservable)
                {
                    reservable.Reserve(customer);
                    var reservation = new Reservation(vehicleId, customer);
                    reservations.Add(reservation);
                    OnNewReservation?.Invoke($"New reserve: {reservation}");
                }
            }
            else
            {
                Console.WriteLine("Not available");
            }
        }

        public void CancelReservation (int vehicleId)
        {
            var reservation = reservations.FirstOrDefault(r=>r.VehicleId == vehicleId);
            if (reservation != null)
            {
                var vehicle = vehicles.FirstOrDefault(v=>v.Id == vehicleId);
                if (vehicle is IReservable reservable)
                {
                    reservable.CancelReservation();
                }
                reservations.Remove(reservation);
                Console.WriteLine("Canceled");
            }
            else
            {
                Console.WriteLine(" Not found");
            }
        }

        public void ListAvailableVehicles()
        {
            var availableVehicles=vehicles.Where(v=> v.IsAvailable).ToList();
            foreach (var vehicle in availableVehicles)
            {
                vehicle.DisplayInfo();
            }
        }
    }
}
