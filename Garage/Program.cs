using Garage.UI;
using Garage.Vehicles;

namespace Garage
{
    internal class Program
    {
        private static readonly ConsoleUI uI = new ConsoleUI();
        private static readonly MenuHandler menuHandler = new MenuHandler(consoleUI: uI);
        private static readonly VehicleCreator creator = new VehicleCreator(menu: menuHandler, uI: uI);
        private static readonly GarageHandler garageHandler = new GarageHandler(cui: uI);
        private static Manager manager = new Manager(cui: uI, menuHandler: menuHandler, creator: creator,garageHandler: garageHandler);
        static void Main(string[] args)
        {
            manager.Do();
        }
    }
}