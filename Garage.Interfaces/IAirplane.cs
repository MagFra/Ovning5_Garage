﻿using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces
{
    public interface IAirplane : IVehicle
    {
        public int NumberOfEngines { get; }
    }
}