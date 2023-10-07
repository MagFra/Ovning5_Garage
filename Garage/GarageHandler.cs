using Garage.Interfaces;
using Garage.UI;

namespace Garage
{
    public class GarageHandler
    {
        private readonly int capacity = 10;
        private readonly IGarage<IVehicle> garage;
        private readonly ConsoleUI uI;
        public GarageHandler(ConsoleUI cui)
        {
            garage = new ParkingGarage<IVehicle>(capacity);
            uI = cui;
        }
        public (IVehicle?,bool) FindeByRegistration(string registration)
        {
            try
            {
                int index = garage.GetIndexByRegistration(registration);
                return (garage.GetVehicleByIndex(index), true);
            }
            catch (Exception)
            {
                return (null,false);
            }

        }
        public void ListAllVehiclesInGarage()
        {
            foreach (var vehicle in garage) { uI.WriteVehicle(vehicle: vehicle, list: true); }
        }
    }
}