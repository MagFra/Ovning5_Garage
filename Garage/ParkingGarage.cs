using Garage.Vehicles;
using Garage.Interfaces;
using System.Collections;
using System.Linq;

namespace Garage
{
    public class ParkingGarage<T> : IGarage<T> where T : IVehicle
    {
        public int Capacity { get; private set; }
        private T[] vehicles = new T[0];
        public int Length => vehicles.Length;
        public bool IsSpaceLeft => Length < Capacity;
        public ParkingGarage(int capacity) => Capacity = capacity;
        public void AddVehicle(T vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(paramName: nameof(vehicle));
            if (!IsSpaceLeft) throw new Exception("This garage is full!");

            int oldSize = vehicles.Length;
            int newSize = oldSize + 1;
            T[] newArray = new T[newSize];
            Array.Copy(vehicles, newArray, oldSize);

            newArray.SetValue(vehicle, oldSize);
            vehicles = newArray;
        }
        public int GetIndexByRegistration(string registration)
        {
            if (string.IsNullOrWhiteSpace(registration))
            {
                throw new ArgumentNullException(paramName: nameof(registration),
                                                message: "There is no registration.");
            }
            registration = registration.ToUpper();
            foreach (T v in vehicles)
            {
                if (v.Registration == registration)
                {
                    return Array.IndexOf(vehicles, v);
                }
            }
            throw new Exception($"No vehicle with the registration \"{registration}\" is parked in this garage.");
        }
        public bool RemoveVehicleByIndex(int index)
        {
            if (index < 0 || index >= vehicles.Length)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index));
            }
            int tempSize = vehicles.Length - 1;
            T[] tempVehicle = new T[tempSize];
            if (index > 0)
            {
                Array.Copy(vehicles, tempVehicle, index);
            }
            if (index < vehicles.Length - 1)
            {
                Array.Copy(vehicles, index + 1, tempVehicle, index, tempVehicle.Length - index);
            }
            vehicles = tempVehicle;
            return vehicles.Length == tempSize;
        }
        public T GetVehicleByIndex(int index)
        {
            if (index < 0 || index >= vehicles.Length)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: $"{nameof(index)}",
                    message: $"Index value must be between 0 and {vehicles.Length - 1}.");
            }
            if (vehicles[index] == null)
            {
                throw new ArgumentException(
                    message: $"The index does not have a vehicle.",
                    paramName: $"{nameof(index)}");
            }
            return vehicles[index];
        }
        public IEnumerable<T>? Find(string? registration = null,
                                    string? brand = null,
                                    string? model = null,
                                    int? year = null,
                                    string? collor = null,
                                    int? nrOfWheels = null)
        {
            registration = registration!.ToUpper();
            IEnumerable<T> tempVehicles;
            tempVehicles = this.vehicles.Where(v => v.Registration == registration);
            return tempVehicles;
        }
        public void RemoveAllVehicles()
        {
            T[] tempVehicles = new T[0];
            vehicles = tempVehicles;
            Array.Clear(vehicles);          
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach ( T vehicle in vehicles)
            {
                yield return vehicle;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
