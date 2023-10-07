namespace Garage.Interfaces
{
    public interface IVehicle
    {
        string Brand { get; }
        string Collor { get; }
        string Model { get; }
        int NrOfWheels { get; }
        string Registration { get; }
        int Year { get; }
    }
}