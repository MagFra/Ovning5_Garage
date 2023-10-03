using Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Boat : Vehicle, IBoat
    {
        public int Lenght { get; private set; }
        public Boat(string registation,
                    string brand,
                    string model,
                    int year,
                    string collor,
                    int nrOfWheels,
                    int lenght)
            
            : base(registation: registation,
                   brand: brand,
                   model: model,
                   year: year,
                   collor: collor,
                   nrOfWheels: nrOfWheels) => Lenght = lenght;
    }
}
