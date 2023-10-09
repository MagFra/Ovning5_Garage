using Garage.Interfaces;
using System.Text;

namespace Garage.UI
{
    public class MenuHandler : IMenuHandler
    {
        private IUI uI;
        public MenuHandler(IUI consoleUI) => uI = consoleUI;
        public int RetrieveMenuChoice(StringBuilder menuStringBuilder, int nrOfChoices, int firstChois = 0)
        // ToDo: Ska i framtiden ta emot ett IMenuObjekt.
        {
            int result = 0, lastChois = firstChois + nrOfChoices - 1;
            bool clr = true, loop = true;
            while (loop)
            {
                if (clr) { uI.Clear(); }
                clr = true;
                ViewMenuText(menuStringBuilder);
                result = RetrieveMenuChoice();
                if (result >= firstChois && result <= lastChois) { return result; }
                uI.Clear(); clr = false; uI.WriteLine("Du måste välja ett alternativ på menyn.");
            }

            return 0;
        }
        private void ViewMenuText(StringBuilder menuStringBuilder)
        {
            string menuText = menuStringBuilder.ToString();
            uI.WriteLine(menuText);
        }
        private int RetrieveMenuChoice()
        {
            while (true)
            {
                if (int.TryParse(uI.ReadLine(), out int result)) { return result; } else { uI.WriteLine("Du måste väja ett nummer."); }
            }
        }
    }
}
