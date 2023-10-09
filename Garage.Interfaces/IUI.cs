namespace Garage.Interfaces
{
    public interface IUI
    {
        void Clear();
        int ReadInt(string text);
        string ReadLine(string text = "", bool verify = true);
        void WriteLine(string text = "");
        void WriteVehicle(IVehicle vehicle, bool list = false);
    }
}