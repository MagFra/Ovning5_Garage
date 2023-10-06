using Garage.UI;
using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class NewVehicleCreator
    {
        private MenuHandler menu;
        public NewVehicleCreator(MenuHandler menu)
        {
            this.menu = menu;
        }
        public IVehicle CreateNewVehicle()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.AppendLine("Välg en fordonstyp!\n");
            menuStringBuilder.AppendLine("1. Flygplan.\n");
            menuStringBuilder.AppendLine("2. Båt.\n");
            menuStringBuilder.AppendLine("3. Buss.\n");
            menuStringBuilder.AppendLine("4. Bil.\n");
            menuStringBuilder.AppendLine("5. Motorcykel.\n");
            menu.ViewMenuText(menuStringBuilder:  menuStringBuilder);
            int chois = menu.RetrieveMenuChoice();



            return null!;
        }
    }
}
