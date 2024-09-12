using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Congestion.Calculator.Contracts;

namespace Congestion.Calculator.Helpers
{
    public static class TollFreeVehicleChecker
    {
        private static readonly List<VehicleTypes> TollFreeVehicles = new List<VehicleTypes>
        {
            VehicleTypes.Motorcycles,
            VehicleTypes.Tractor,
            VehicleTypes.Emergency,
            VehicleTypes.Diplomat,
            VehicleTypes.Foreign,
            VehicleTypes.Military
        };

        public static bool IsTollFreeVehicle(IVehicle vehicle)
        {
            return TollFreeVehicles.Contains(vehicle.GetVehicleType());
        }
    }
}