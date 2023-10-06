using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;

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
            foreach (var vehicle in garage) { WriteVehicle(vehicle: vehicle, list: true); }
        }
        public void WriteVehicle(IVehicle vehicle, bool list = false)
        {
            if (list) { uI.WriteLine(); } else { uI.Clear(); }
            if (vehicle is IAirplane airplane) { uI.WriteLine(airplane.ToString()!); }
            if (vehicle is IBoat boat) { uI.WriteLine(boat.ToString()!); }
            if (vehicle is IBus bus) { uI.WriteLine(bus.ToString()!); }
            if (vehicle is ICar car) { uI.WriteLine(car.ToString()!); }
            if (vehicle is IMotorcycle motorcycle) { uI.WriteLine(motorcycle.ToString()!); }
            if (!list) _ = uI.ReadLine(verify: false);
        }
    }
}