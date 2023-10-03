using Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Car : Vehicle, ICar
    {
        public string Fueltype { get; private set; }
        public Car(string registation,
                   string brand,
                   string model,
                   int year,
                   string collor,
                   int nrOfWheels,
                   string fueltype)
            : base(registation: registation,
                   brand: brand,
                   model: model,
                   year: year,
                   collor: collor,
                   nrOfWheels: nrOfWheels) => Fueltype = fueltype;
    }
}
