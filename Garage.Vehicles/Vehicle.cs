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

        
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType != this.GetType) return false;
            Vehicle v = (Vehicle)obj;

            if (v.Registration == Registration ||
                v.Brand == Brand ||
                v.Model == Model ||
                v.Year == Year ||
                v.Collor == Collor ||
                v.NrOfWheels == NrOfWheels) return true; else return false;
        }

        public override int GetHashCode() => base.GetHashCode();
        // Jag är heligt ointreserad av GetHashCode().
        // Men VS krävde att jag gjorde en "override" på den när jag gjorde det på Equals().           
    }
}