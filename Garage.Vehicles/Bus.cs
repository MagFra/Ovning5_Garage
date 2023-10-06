using Garage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public class Bus : Vehicle, IBus
    {
        public int NumberOfSeats { get; private set; }
        public Bus(string registation,
                   string brand,
                   string model,
                   int year,
                   string collor,
                   int nrOfWheels,
                   int numberOfSeats)

            : base(registation: registation,
                   brand: brand,
                   model: model,
                   year: year,
                   collor: collor,
                   nrOfWheels: nrOfWheels)
        {
            NumberOfSeats = numberOfSeats;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Bussen:\n");
            sb.Append(base.ToString());
            sb.Append($"Atalet sittplatser:\t[{NumberOfSeats}]\n");
            return sb.ToString();
        }
    }
}
