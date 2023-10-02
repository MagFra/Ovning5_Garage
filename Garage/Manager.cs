using System.Text;
using ConsoleUI;

namespace Garage
{
    public class Manager
    {
        private ConsoleUI.ConsoleUI uI;
        public Manager(ConsoleUI.ConsoleUI cui) { this.uI = cui; }
        public int Menu()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.AppendLine("1. jkhdh.");
            menuStringBuilder.AppendLine("2. jkhdh.");
            menuStringBuilder.AppendLine("3. jkhdh.");
            menuStringBuilder.AppendLine("0. Anvsluta.");
            string menuText = menuStringBuilder.ToString();
            uI.WriteLine(menuText);
            return 0;
        }
    }
}
