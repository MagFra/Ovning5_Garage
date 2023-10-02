using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class ConsoleUI
    {
        public void WriteLine(string text) => Console.WriteLine(text);
        public string ReadLine()
        {
            string? line;
            do
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) { WriteLine("Du måste skriva något."); }
            } while (string.IsNullOrEmpty(line));
            return line;
        }
    }
}
