using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleReservationSystem
{
    public class Car: Vehicle, IReservable
    {
        public string BodyType { get; set; }

        public Car(int id, string brand, string model, int year, string bodyType):base(id,brand,model,year)
        {
            BodyType = bodyType;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($" Car {Brand} {Model} {Year} {BodyType} {IsAvailable} ");
        }

        public override void Reserve(string customer)
        {
            if (IsAvailable)
            {
                Console.WriteLine($"car reserved by {customer}");
                IsAvailable = false;
            }
            else
            {
                Console.WriteLine("Car not available");
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
