using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
