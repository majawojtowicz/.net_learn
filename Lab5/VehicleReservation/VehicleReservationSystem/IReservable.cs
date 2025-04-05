using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleReservationSystem
{
    public interface IReservable
    {
        void Reserve(string customer);
        void CancelReservation();
        bool IsAvailable();
    }
}
