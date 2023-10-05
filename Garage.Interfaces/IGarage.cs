using Garage.Vehicles;

namespace Garage
{
    public interface IGarage<T>: IEnumerable<T> where T : IVehicle
    {
        int Capacity { get; }
        bool IsSpaceLeft { get; }
        int Length { get; }

        void AddVehicle(T vehicle);
        T ByIndex(int index);
        int GetIndexByRegistration(string registration);
        bool RemoveVehicleByIndex(int index);
    }
}