using Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        public int CylinderVolume { get; private set; }
        public Motorcycle(string registation,
                          string brand,
                          string model,
                          int year,
                          string collor,
                          int nrOfWheels,
                          int cylinderVolume)

                    : base(registation: registation,
                           brand: brand,
                           model: model,
                           year: year,
                           collor: collor,
                           nrOfWheels: nrOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
    }
}
