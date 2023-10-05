using Garage.Vehicles;

namespace Garage
{
    public class GarageHandler
    {
        private readonly int capacity = 10;
        private readonly IGarage<IVehicle> garage;
        public GarageHandler() => garage = new ParkingGarage<IVehicle>(capacity);
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

    }
}