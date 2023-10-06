using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
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
        public void ViewMenuText(StringBuilder menuStringBuilder) // ToDo: Ska i framtiden ta emot ett IMenuObjekt som bl.a. innehåller meny texten.
        {
            string menuText = menuStringBuilder.ToString();
            uI.WriteLine(menuText);
        }
        public int RetrieveMenuChoice()
        {
            while (true)
            {
                if (int.TryParse(uI.ReadLine(), out int result)) { return result; } else { uI.WriteLine("Du måste väja ett nummer."); }
            } 
        }
        public int RetrieveMenuChoice(StringBuilder menuStringBuilder, int nrOfChoices, int min = 0)
        {
            int result = 0, max = min + nrOfChoices - 1;
            bool clr = true, loop = true;
            while (loop)
            {
                if (clr) { uI.Clear(); }
                clr = true;
                ViewMenuText(menuStringBuilder);
                result = RetrieveMenuChoice();
                if(result >= min && result <= max) { return result; }
                uI.Clear(); clr = false; uI.WriteLine("Du måste välja ett alternativ på menyn.");
            }

            return 0;
        }
    }
}
