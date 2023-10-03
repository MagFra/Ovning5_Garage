namespace Garage.Vehicles
{
    public interface IVehicle
    {
        string Brand { get; }
        string Collor { get; }
        string Model { get; }
        int NrOfWheels { get; }
        string Registation { get; }
        int Year { get; }
    }
}