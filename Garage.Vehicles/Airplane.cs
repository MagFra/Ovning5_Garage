using System.Text;
using Garage.Interfaces;

namespace Garage.Vehicles
{
    public class Airplane : Vehicle, IAirplane
    {
        public int NumberOfEngines { get; private set; }
        public Airplane(string registation, 
                        string brand, 
                        string model, 
                        int year, 
                        string collor, 
                        int nrOfWheels, 
                        int numberOfEngines)
            : base(registation: registation,
                   brand: brand,
                   model: model,
                   year: year,
                   collor: collor,
                   nrOfWheels: nrOfWheels) => NumberOfEngines = numberOfEngines;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Flygplanet:\n");
            sb.Append(base.ToString());
            sb.Append($"Atalet motorer:\t\t[{NumberOfEngines}]\n");
            return sb.ToString();
        }
    }
}
