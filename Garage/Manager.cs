using Garage.UI;

using System.Text;

namespace Garage
{
    public class Manager
    {
        private readonly ConsoleUI uI;
        private readonly MenuHandler menuHandler;
        public Manager(ConsoleUI cui, MenuHandler menuHandler)
        { 
            uI = cui;
            this.menuHandler = menuHandler;
        }
        public void Do()
        {
            bool clr = true;
            bool loop = true;
            while (loop)
            {
                if (clr) { uI.Clear(); }
                clr = true;
                switch (Menu()) 
                {
                    case 1: { break; }
                    case 2: { break; }
                    case 3: { break; }
                    case 0: {uI.Clear(); uI.WriteLine("Hej då!"); loop = false; break; }
                    default: { uI.Clear(); clr = false; uI.WriteLine("Du måste välja ett alternativ på menyn."); break; }
                }
            }
        }
        public int Menu()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.AppendLine("1. jkhdh.");
            menuStringBuilder.AppendLine("2. jkhdh.");
            menuStringBuilder.AppendLine("3. jkhdh.");
            menuStringBuilder.AppendLine("0. Anvsluta.");

            menuHandler.ViewMenuText(menuStringBuilder); // ToDo: Ska i framtiden skicka ett MenuObjekt som uppfyller IMenu Interfacet. Då kan ovanstående menybygge utelämnas.

            return menuHandler.RetrieveMenuChoice();
        }
    }
}
