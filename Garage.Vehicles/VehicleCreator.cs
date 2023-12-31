﻿using Garage.Interfaces;
using Garage.UI;
using System.Text;

namespace Garage.Vehicles
{
    public class VehicleCreator : IVehicleCreator
    {
        private IMenuHandler menu;
        private IUI uI;
        public VehicleCreator(IMenuHandler menu, IUI uI)
        {
            this.menu = menu;
            this.uI = uI;
        }
        public IVehicle CreateNewVehicle()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.Append("Välg en fordonstyp!\n");
            menuStringBuilder.Append("1. Flygplan.\n");
            menuStringBuilder.Append("2. Båt.\n");
            menuStringBuilder.Append("3. Buss.\n");
            menuStringBuilder.Append("4. Bil.\n");
            menuStringBuilder.Append("5. Motorcykel.\n");
            int firstChois = 1, nrOfChoices = 5; // (1 - 5) Inclusive.
            int chois = menu.RetrieveMenuChoice(menuStringBuilder: menuStringBuilder,
                                                nrOfChoices: nrOfChoices,
                                                firstChois: firstChois);
            string vehicle = string.Empty;
            switch (chois)
            {
                case 1: { vehicle = "Flygplan:"; break; }
                case 2: { vehicle = "Båt:"; break; }
                case 3: { vehicle = "Buss:"; break; }
                case 4: { vehicle = "Bil:"; break; }
                case 5: { vehicle = "Motorcykel:"; break; }
            }
            uI.Clear(); uI.WriteLine(vehicle);
            string registration = uI.ReadLine("Ange registreringsnummer: ").Trim().ToUpper();
            string brand = uI.ReadLine("Ange märke: ").Trim();
            string model = uI.ReadLine("Ange modell: ").Trim();
            int year = uI.ReadInt("Ange årsmodell: ");
            string collor = uI.ReadLine("Ange färg: ").Trim();
            int nrOfWheels;
            if (chois == 2) { nrOfWheels = 0; } else { nrOfWheels = uI.ReadInt("Ange antalet hjul: "); }
            switch (chois)
            {
                case 1:
                    {
                        return MakeAirplane(registation: registration,
                                              brand: brand,
                                              model: model,
                                              year: year,
                                              collor: collor,
                                              nrOfWheels: nrOfWheels);
                    }
                case 2:
                    {
                        return MakeBoat(registation: registration,
                                              brand: brand,
                                              model: model,
                                              year: year,
                                              collor: collor,
                                              nrOfWheels: nrOfWheels);
                    }
                case 3:
                    {
                        return MakeBus(registation: registration,
                                              brand: brand,
                                              model: model,
                                              year: year,
                                              collor: collor,
                                              nrOfWheels: nrOfWheels);
                    }
                case 4:
                    {
                        return MakeCar(registation: registration,
                                              brand: brand,
                                              model: model,
                                              year: year,
                                              collor: collor,
                                              nrOfWheels: nrOfWheels);
                    }
                case 5:
                    {
                        return MakeMotorcykle(registation: registration,
                                              brand: brand,
                                              model: model,
                                              year: year,
                                              collor: collor,
                                              nrOfWheels: nrOfWheels);
                    }
            }

            return null!;
        }
        private IAirplane MakeAirplane(string registation, string brand, string model, int year, string collor, int nrOfWheels)
        {
            int numberOfEngines = uI.ReadInt("Ange antalet motorer: ");
            return new Airplane(registation: registation,
                                brand: brand,
                                model: model,
                                year: year,
                                collor: collor,
                                nrOfWheels: nrOfWheels,
                                numberOfEngines: numberOfEngines);
        }
        private IBoat MakeBoat(string registation, string brand, string model, int year, string collor, int nrOfWheels)
        {
            int lenght = uI.ReadInt("Ange båtens längd: ");
            return new Boat(registation: registation,
                            brand: brand,
                            model: model,
                            year: year,
                            collor: collor,
                            nrOfWheels: nrOfWheels,
                            lenght: lenght);
        }
        private IBus MakeBus(string registation, string brand, string model, int year, string collor, int nrOfWheels)
        {
            int numberOfSeats = uI.ReadInt("Ange antalet sittplatser i bussen: ");
            return new Bus(registation: registation,
                           brand: brand,
                           model: model,
                           year: year,
                           collor: collor,
                           nrOfWheels: nrOfWheels,
                           numberOfSeats: numberOfSeats);
        }
        private ICar MakeCar(string registation, string brand, string model, int year, string collor, int nrOfWheels)
        {
            string fueltype = uI.ReadLine("Ange vad för bränsle din bil använder: ").Trim();
            return new Car(registation: registation,
                           brand: brand,
                           model: model,
                           year: year,
                           collor: collor,
                           nrOfWheels: nrOfWheels,
                           fueltype: fueltype);
        }
        private IMotorcycle MakeMotorcykle(string registation, string brand, string model, int year, string collor, int nrOfWheels)
        {
            int cylinderVolume = uI.ReadInt("Ange din motorcykels cylindervolym: ");
            return new Motorcycle(registation: registation,
                                  brand: brand,
                                  model: model,
                                  year: year,
                                  collor: collor,
                                  nrOfWheels: nrOfWheels,
                                  cylinderVolume: cylinderVolume);
        }
    }
}
