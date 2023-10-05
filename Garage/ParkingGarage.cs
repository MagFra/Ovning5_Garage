using Garage.Vehicles;
using System.Collections;

namespace Garage
{
    public class ParkingGarage<T> : IGarage<T> where T : IVehicle
    {
        public int Capacity { get; private set; }
        private T[] _vehicles = new T[0];
        public int Length => _vehicles.Length;
        public bool IsSpaceLeft => Length < Capacity;
        public ParkingGarage(int capacity) => Capacity = capacity;
        public void AddVehicle(T vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(paramName: nameof(vehicle));
            if (!IsSpaceLeft) throw new Exception("This garage is full!");

            int oldSize = _vehicles.Length;
            int newSize = oldSize + 1;
            T[] newArray = new T[newSize];
            Array.Copy(_vehicles, newArray, oldSize);

            newArray.SetValue(vehicle, oldSize);
            _vehicles = newArray;
        }
        public int GetIndexByRegistration(string registration)
        {
            if (string.IsNullOrWhiteSpace(registration))
            {
                throw new ArgumentNullException(paramName: nameof(registration),
                                                message: "There is no registration.");
            }
            foreach (T v in _vehicles)
            {
                if (v.Registration == registration)
                {
                    return Array.IndexOf(_vehicles, v);
                }
            }
            throw new Exception($"No vehicle with the registration \"{registration}\" is parked in this garage.");
        }
        public bool RemoveVehicleByIndex(int index)
        {
            if (index < 0 || index >= _vehicles.Length)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index));
            }
            int tempSize = _vehicles.Length - 1;
            T[] tempVehicle = new T[tempSize];
            if (index > 0)
            {
                Array.Copy(_vehicles, tempVehicle, index);
            }
            if (index < _vehicles.Length - 1)
            {
                Array.Copy(_vehicles, index + 1, tempVehicle, index, tempVehicle.Length - index);
            }
            _vehicles = tempVehicle;
            return _vehicles.Length == tempSize;
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
            yield return (T)_vehicles.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
