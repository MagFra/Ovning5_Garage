using Garage;
using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

IConfiguration config = new ConfigurationBuilder()
                                .SetBasePath(Environment.CurrentDirectory)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
var capacity = int.Parse(config.GetSection("Garage:capacity").Value!);

//var host = Host.CreateDefaultBuilder(args)
//               .ConfigureServices(services =>
//               {
//                   services.AddSingleton<IConfiguration>(config);
//                   services.AddSingleton<IUI, ConsoleUI>();
//                   services.AddSingleton<IMenuHandler, MenuHandler>();
//                   services.AddSingleton<IGarage<IVehicle>, ParkingGarage<IVehicle>>();
//                   services.AddSingleton<IGarageHandler, GarageHandler>();
//                   services.AddSingleton<IManager, Manager>();
//                   services.AddSingleton<IVehicleCreator, VehicleCreator>();
//               })
//               .UseConsoleLifetime()
//               .Build();
// host.Services.GetRequiredService<IManager>().Do();

// Det sket sig när något efterfrågade IVehicle. Efter som det ska vara flera fordon vågar jag inte göra en "Singleton". Så jag gick tillbaka till det som fugerade.

IUI uI = new ConsoleUI();
IMenuHandler menuHandler = new MenuHandler(consoleUI: uI);
IVehicleCreator creator = new VehicleCreator(menu: menuHandler, uI: uI);
IGarage<IVehicle> garage = new ParkingGarage<IVehicle>(capacity: capacity);
IGarageHandler garageHandler = new GarageHandler(cui: uI, garage: garage);
IManager manager = new Manager(cui: uI, menuHandler: menuHandler, creator: creator, garageHandler: garageHandler);
manager.Do();