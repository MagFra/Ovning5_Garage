namespace Garage.Interfaces
{
    public interface IGarage<T>: IEnumerable<T> where T : IVehicle
    {
        int Capacity { get; }
        bool IsSpaceLeft { get; }
        int Length { get; }

        void AddVehicle(T vehicle);
        T GetVehicleByIndex(int index);
        int GetIndexByRegistration(string registration);
        public IEnumerable<T> GroupedList();
        bool RemoveVehicleByIndex(int index);
        void RemoveAllVehicles();
        IEnumerable<T>? Find(string? registration = null,
                             string? brand = null,
                             string? model = null,
                             int? Year = null,
                             string? collor = null,
                             int? nrOfWheels = null);
    }
}