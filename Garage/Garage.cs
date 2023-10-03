using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private readonly T[] _vehicles;
        public Garage(int size)
        {
            _vehicles = new T[size];
            Array.Clear(_vehicles);
        }
        public void AddVehicle(T vehicle)
        {
            if(vehicle == null) throw new ArgumentNullException(paramName: nameof(vehicle));
            if (_vehicles.Length <= _vehicles.Count()) throw new Exception("The garage is full!");
            // _vehicles[0]. = vehicle;
            _vehicles.SetValue(vehicle, 0);
        }
        public T ByIndex(int index)
        {
            if (index < 0 || index >= _vehicles.Length) 
            {
                throw new ArgumentOutOfRangeException(
                    paramName: $"{nameof(index)}",
                    message: $"Index value must be between 0 and {_vehicles.Length - 1}.");
            }
            if (_vehicles[index] == null)
            {
                throw new ArgumentException(
                    message: $"The index does not have a vehicle.",
                    paramName: $"{nameof(index)}");
            }
            return _vehicles[index]; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in _vehicles)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
