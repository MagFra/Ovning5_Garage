using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ParkingGarage<T> : IEnumerable<T> where T : IVehicle
    {
        private int maxSize;
        private T[] _vehicles = new T[0];
        public ParkingGarage(int size)
        {
            this.maxSize = size;
        }
        public void AddVehicle(T vehicle)
        {
            if(vehicle == null) throw new ArgumentNullException(paramName: nameof(vehicle));
            // if (_vehicles.Length <= _vehicles.Count()) throw new Exception("The garage is full!");

            int oldSize = _vehicles.Length;
            int newSize = oldSize + 1;
            T[] newArray = new T[newSize];
            Array.Copy(_vehicles, newArray, oldSize);

            newArray.SetValue(vehicle, oldSize);
            _vehicles = newArray;
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
        public int Length() => _vehicles.Length;

        public IEnumerator<T> GetEnumerator()
        {
            yield return (T)_vehicles.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
