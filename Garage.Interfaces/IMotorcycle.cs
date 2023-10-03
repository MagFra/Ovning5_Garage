using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces
{
    public interface IMotorcycle: IVehicle
    {
        public int CylinderVolume { get;}
    }
}
