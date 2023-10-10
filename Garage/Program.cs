using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
var capacity = int.Parse(config.GetSection("Garage:capacity").Value!);

var x = 1;

namespace Garage
{
    internal class Program
    {
        private static readonly int capacity = 10;
        private static readonly IUI uI = new ConsoleUI();
        private static readonly IMenuHandler menuHandler = new MenuHandler(consoleUI: uI);
        private static readonly IVehicleCreator creator = new VehicleCreator(menu: menuHandler, uI: uI);
        private static readonly IGarage<IVehicle> garage = new ParkingGarage<IVehicle>(capacity: capacity);
        private static readonly IGarageHandler garageHandler = new GarageHandler(cui: uI, garage: garage );
        private static readonly IManager manager = new Manager(cui: uI, menuHandler: menuHandler, creator: creator,garageHandler: garageHandler);
        static void Main(string[] args)
        {
            manager.Do();
        }
    }
}