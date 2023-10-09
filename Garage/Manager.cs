using Garage.Interfaces;
using Garage.UI;
using Garage.Vehicles;
using System.Text;

namespace Garage
{
    public class Manager
    {
        private readonly IUI uI;
        private readonly IMenuHandler menuHandler;
        private readonly IVehicleCreator creator;
        private readonly GarageHandler garageHandler;
        public Manager(IUI cui, IMenuHandler menuHandler, IVehicleCreator creator, GarageHandler garageHandler)
        { 
            uI = cui;
            this.menuHandler = menuHandler;
            this.creator = creator;
            this.garageHandler = garageHandler;
        }
        public void Do()
        {
            bool clr = true;
            bool loop = true;
            while (loop)
            {
                if (clr) { uI.Clear(); }
                clr = true;
                switch (MainMenu()) 
                {
                    case 1: { Park(); break; }
                    case 2: { Collect(); break; }
                    case 3: { SergeRegistration(); break; }
                    case 4: { Search(); break; }
                    case 5: { List(); break; }
                    case 0: {uI.Clear(); uI.WriteLine("Hej då!"); loop = false; break; }
                    default: { uI.Clear(); clr = false; uI.WriteLine("Du måste välja ett alternativ på menyn."); break; }
                }
            }
        }
        private int MainMenu()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.AppendLine("1. Parkera.");
            menuStringBuilder.AppendLine("2. Hämta ut.");
            menuStringBuilder.AppendLine("3. Sök på registreringsnummer.");
            menuStringBuilder.AppendLine("4. Sök.");
            menuStringBuilder.AppendLine("5. Lista");
            menuStringBuilder.AppendLine("0. Avsluta.");
            int nrOfChoices = 6; // (0 - 5) Inclusive.

            return menuHandler.RetrieveMenuChoice(menuStringBuilder: menuStringBuilder, nrOfChoices: nrOfChoices);
            // ToDo: Ska i framtiden skicka ett MenuObjekt som uppfyller IMenu Interfacet. Då kan ovanstående menybygge utelämnas.
        }
        private void Park()
        {
            if(!garageHandler.HasSpace)
            {
                uI.WriteLine("Vi kan tyvärr inte parkera några nya fordon just nu. Garget är fullt.");
                _ = uI.ReadLine(verify: false);
                return;
            }
            IVehicle newVehicle = creator.CreateNewVehicle();
            _ = uI.ReadLine(verify:false);
            uI.Clear();
            uI.WriteLine("Du har registrerat:");
            uI.WriteVehicle(vehicle: newVehicle, list: true);
            string registration = newVehicle.Registration;
            IVehicle? oldVehicle; bool result;
            (oldVehicle, result ) = garageHandler.FindeByRegistration(registration: registration);
            if(result)
            {
                uI.WriteLine("Du kan inte parkera här!\nDet finns redan ett fordon med samma registreringsnummer parkerat här.");
                _ = uI.ReadLine(verify:false);
                return;
            }
            result = garageHandler.TryPark(vehicle: newVehicle);
            if(!result)
            {
                uI.WriteLine("Okänt fel vid parkeringen!\nTrots våra rigorösa kontroller av både utrymme i garaget och att det inte är en dublett av registreringsnumret, så verkar det som om något av dem förhindrare oss att parkera ditt fordon.");
                _ = uI.ReadLine(verify: false);
                return;
            }
            uI.WriteLine("Vi har parkerat ditt fordon.");
            _ = uI.ReadLine(verify: false);
        }
        private void Collect()
        {
            string registration = uI.ReadLine(text: "Ange registreringsnummer: ");
            IVehicle? tempVehicle; bool result;
            (tempVehicle, result)= garageHandler.FindeByRegistration(registration: registration);
            if (!result)
            {
                _ = uI.ReadLine($"{registration.ToUpper()} återfinns inte i garaget.");
                return;
            }
            bool success = garageHandler.UnparkByRegistration(registration);
            // Inte implementerad.
        }
        private void SergeRegistration()
        {
            // Inte implementerad.
        }
        private void Search()
        {
            _ = uI.ReadLine("Testar att söka på registreringsnummer: [ABC123].", verify: false);
            bool gotIt = garageHandler.Find(registration: "abc123");
            if (!gotIt) { uI.WriteLine("Inga fordon machade din sökning."); }
            _ = uI.ReadLine(verify: false);
            // Inte implementerad.
        }
        private void List()
        {
            StringBuilder menuStringBuilder = new StringBuilder();
            menuStringBuilder.AppendLine("1. Enkel lista.");
            menuStringBuilder.AppendLine("2. Grupperad lista.");
            int firstChois = 1, nrOfChoises = 2;    // (1 - 2) inclusiv.
            int chois = menuHandler.RetrieveMenuChoice(menuStringBuilder: menuStringBuilder,
                                                       nrOfChoices: nrOfChoises,
                                                       firstChois: firstChois);
            switch (chois)
            {
                case 1: { garageHandler.ListAllVehiclesInGarage(); uI.ReadLine(verify: false) ; break; }
                case 2: { _ = uI.ReadLine(text: "Grupperad lista har inte implementerats än!", verify: false); break; }
            }
            // Inte implementerad.
        }
    }
}
