using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class ConsoleUI
    {
        public void WriteLine(string text = "") => Console.WriteLine(text);
        public string? ReadLine(string text = "", bool verify = true)
        {
            string? line;
            do
            {
                Console.Write(text);
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line) && verify) { WriteLine("Du måste skriva något."); }
            } while (string.IsNullOrEmpty(line) && verify);
            return line;
        }
        public int ReadInt(string text)
        {
            while (true) 
            { 
                if(int.TryParse(ReadLine(text), out int result)) return result;
                WriteLine("Du måste ange ett giltigt heltal.");
            }
        }
        public void Clear() => Console.Clear();
    }
}
