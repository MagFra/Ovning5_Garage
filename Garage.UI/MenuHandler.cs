using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.UI
{
    public class MenuHandler
    {
        private ConsoleUI uI;
        public MenuHandler(ConsoleUI consoleUI)
        {
            uI = consoleUI;
        }
        public void ViewMenuText(string menuText) // ToDo: Ska i framtiden ta emot ett IMenuObjekt som bl.a. innehåller meny texten.
        {
            uI.WriteLine(menuText);
        }
        public int RetrieveMenuChoice()
        {
            while (true)
            {
                if (int.TryParse(uI.ReadLine(), out int result)) { return result; } else { uI.WriteLine("Du måste väja ett nummer."); }
            } 
        }
    }
}
