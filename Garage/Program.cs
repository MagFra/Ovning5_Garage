using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;

namespace Garage
{
    internal class Program
    {
        private static readonly int capacity = 10;
        private static readonly IUI uI = new ConsoleUI();
        private static readonly IMenuHandler menuHandler = new MenuHandler(consoleUI: uI);
        private static readonly IVehicleCreator creator = new VehicleCreator(menu: menuHandler, uI: uI);
        private static readonly IGarage<IVehicle> garage = new ParkingGarage<IVehicle>(capacity: capacity);
        private static readonly GarageHandler garageHandler = new GarageHandler(cui: uI, garage: garage );
        private static Manager manager = new Manager(cui: uI, menuHandler: menuHandler, creator: creator,garageHandler: garageHandler);
        static void Main(string[] args)
        {
            manager.Do();
        }
    }
}