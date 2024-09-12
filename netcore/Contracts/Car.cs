using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congestion.Calculator.Contracts
{
    public class Car : IVehicle
    {
        public VehicleTypes GetVehicleType()
        {
            return VehicleTypes.Car;
        }
    }
}