using Garage.Interfaces;

namespace Garage.UI
{
    public class ConsoleUI : Interfaces.IUI
    {
        public void WriteLine(string text = "") => Console.WriteLine(text);
        public string ReadLine(string text = "", bool verify = true)
        {
            string? line;
            do
            {
                Console.Write(text);
                line = Console.ReadLine();
                if (!verify) { return string.Empty; }
                if (string.IsNullOrEmpty(line)) { WriteLine("Du måste skriva något."); }
            } while (string.IsNullOrEmpty(line));
            return line;
        }
        public int ReadInt(string text)
        {
            while (true)
            {
                if (int.TryParse(ReadLine(text), out int result)) return result;
                WriteLine("Du måste ange ett giltigt heltal.");
            }
        }
        public void Clear() => Console.Clear();
        public void WriteVehicle(IVehicle vehicle, bool list = false)
        {
            if (!list) { Clear(); }
            if (vehicle is IAirplane airplane) { WriteLine(airplane.ToString()!); }
            if (vehicle is IBoat boat) { WriteLine(boat.ToString()!); }
            if (vehicle is IBus bus) { WriteLine(bus.ToString()!); }
            if (vehicle is ICar car) { WriteLine(car.ToString()!); }
            if (vehicle is IMotorcycle motorcycle) { WriteLine(motorcycle.ToString()!); }
            if (list) { WriteLine(); } else _ = ReadLine(verify: false);
        }
    }
}