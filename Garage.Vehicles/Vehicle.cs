using Garage.Interfaces;
using System.Reflection;
using System.Text;

namespace Garage.Vehicles
{
    public class Vehicle : IVehicle
    {
        private string registration = string.Empty;
        public string Registration { get => registration; private set => registration = VerifyRegistration(value).ToUpper(); }
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
        protected virtual string VerifyRegistration(string registration)
        {
            if (string.IsNullOrWhiteSpace(registration))
            {
                throw new ArgumentNullException(paramName: nameof(registration), message: "Registration is missing!");
            }
            return registration.Trim();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Registreringsnummer:\t[{registration}]\n");
            sb.Append($"Fabrikat:\t\t[{Brand}]\n");
            sb.Append($"Modell:\t\t\t[{Model}]\n");
            sb.Append($"Årsmodell:\t\t[{Year}]\n");
            sb.Append($"Färg:\t\t\t[{Collor}]\n");
            if (this.GetType() != typeof(Boat)) { sb.Append($"Antal hjul:\t\t[{NrOfWheels}]\n"); }
            return sb.ToString();
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