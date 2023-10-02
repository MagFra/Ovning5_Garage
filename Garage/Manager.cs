using Garage.UI;
using System.Text;

namespace Garage
{
    public class Manager
    {
        private ConsoleUI uI;
        public Manager(ConsoleUI cui) { uI = cui; }
        public int Menu()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.AppendLine("1. jkhdh.");
            menuStringBuilder.AppendLine("2. jkhdh.");
            menuStringBuilder.AppendLine("3. jkhdh.");
            menuStringBuilder.AppendLine("0. Anvsluta.");
            string menuText = menuStringBuilder.ToString();
            uI.WriteLine(menuText);
            if (int.TryParse(uI.ReadLine(), out int result)) {/*Error*/}

            return result; // Ska jag använda en "Tuple"? (int result, bool ok)
        }
    }
}
