using Garage.Interfaces;
using Garage.UI;

namespace Garage
{
    public class GarageHandler
    {
        private readonly IGarage<IVehicle> garage;
        private readonly IUI uI;
        private int myVar;

        public bool HasSpace => garage.IsSpaceLeft;
        public GarageHandler(IUI cui, IGarage<IVehicle> garage )
        {
            this.garage = garage;
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
        public bool TryPark(IVehicle vehicle) 
        {
            if (!garage.IsSpaceLeft) return false;
            try
            {
                garage.AddVehicle(vehicle);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public void ListAllVehiclesInGarage()
        {
            if (garage.Length == 0)
            {
                uI.WriteLine("Det finns inga fordon att lista!");
                return; 
            }
            uI.Clear();
            foreach (var vehicle in garage)
            { uI.WriteVehicle(vehicle: vehicle, list: true); }
        }
        public bool Find(string? registration = null,
                         string? brand = null,
                         string? model = null,
                         int? year = null,
                         string? collor = null,
                         int? nrOfWheels = null)
        {
            IEnumerable<IVehicle>? tempVehicles = garage.Find(registration: registration,
                                                              brand: brand,
                                                              model: model,
                                                              Year: year,
                                                              collor: collor,
                                                              nrOfWheels: nrOfWheels);
            if(tempVehicles!.Count() == 0) return false;
            foreach (var vehicle in tempVehicles!)
            {
                uI.WriteVehicle(vehicle: vehicle, list: true);
            }
            return true;
        }

        internal bool UnparkByRegistration(string registration)
        {

            return false;
        }
    }
}