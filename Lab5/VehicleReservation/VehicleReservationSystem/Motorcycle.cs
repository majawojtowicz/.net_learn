using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleReservationSystem
{
    public class Motorcycle: Vehicle, IReservable
    {
        public int EngineCapacity { get; set; }

        public Motorcycle(int id, string brand, string model, int year, int engineCapacity): base(id,brand, model, year)
        {
            EngineCapacity = engineCapacity;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($" Motorcycle {Brand} {Model} {Year} {EngineCapacity} {IsAvailable} ");
        }

        public override void Reserve(string customer)
        {
            if (IsAvailable)
            {
                Console.WriteLine($"motorcycle reserved by {customer}");
                IsAvailable = false;
            }
            else
            {
                Console.WriteLine("Motorcycle not available");
            }
        }

        public override void CancelReservation()
        {
            if (!IsAvailable)
            {
                Console.WriteLine("reservation cancelled");
                IsAvailable = true;
            }
        }
        bool IReservable.IsAvailable()
        {
            return IsAvailable;
        }
    }
}
