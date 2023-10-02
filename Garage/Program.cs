using Garage.UI;

namespace Garage
{
    internal class Program
    {
        private static readonly ConsoleUI uI = new ConsoleUI();
        private static MenuHandler menuHandler = new MenuHandler(uI);
        private static Manager manager = new Manager(uI, menuHandler);
        static void Main(string[] args)
        {
            manager.Do();
        }
    }
}