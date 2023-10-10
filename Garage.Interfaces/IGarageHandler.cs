namespace Garage.Interfaces
{
    public interface IGarageHandler
    {
        bool HasSpace { get; }

        bool Find(string? registration = null, string? brand = null, string? model = null, int? year = null, string? collor = null, int? nrOfWheels = null);
        (IVehicle?, bool) FindeByRegistration(string registration);
        void ListAllVehiclesInGarage(bool group = false);
        bool TryPark(IVehicle vehicle);
        bool UnparkByRegistration(string registration);
    }
}