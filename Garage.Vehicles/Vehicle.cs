using System.Reflection;

namespace Garage.Vehicles
{
    public class Vehicle : IVehicle
    {
        public string Registration { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public string Collor { get; private set; }
        public int NrOfWheels { get; private set; }


        public Vehicle(string registation, string brand, string model, int year, string collor, int nrOfWheels)
        {
            Registration = registation;
            Brand = brand;
            Model = model;
            Year = year;
            Collor = collor;
            NrOfWheels = nrOfWheels;
        }
    }
}