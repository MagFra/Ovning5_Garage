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
                    case 3: { SearchRegistration(); break; }
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
            string registration = uI.ReadLine(text: "Ange registreringsnummer: ").ToUpper();
            bool success;
            (_, success)= garageHandler.FindeByRegistration(registration: registration);
            if (!success)
            {
                _ = uI.ReadLine($"{registration} återfinns inte i garaget.",verify: false);
                return;
            }
            success = garageHandler.UnparkByRegistration(registration);
            if (success)
            {
                uI.WriteLine($"{registration} har tagits ut ur garaget.");
            }
            _ = uI.ReadLine(verify: false);
        }
        private void SearchRegistration()
        {
            string registration = uI.ReadLine("Ange registreringsnummer: ").ToUpper();
            IVehicle? vehicle; bool success;
            (vehicle,success) = garageHandler.FindeByRegistration(registration: registration);
            if (success)
            { 
                uI.WriteVehicle(vehicle!); 
            }
            else
            {
                _ = uI.ReadLine($"{registration} återfinns inte i garaget.", verify: false);
            }
        }
        private void Search()
        {
            string? registrtion = string.Empty, brand = string.Empty, model = string.Empty, collor = string.Empty, sYear, sNrOfWheels, svar; int? year = 0, nrOfWheels = 0;
            bool loop = true;
            while(loop)
            {
                StringBuilder explonationSB = new StringBuilder();
                explonationSB.AppendLine("Här får du möjligheten att söka på flera olika fordonsegenskaper!\n");
                explonationSB.AppendLine("Du kommer att tillfrågas om sökkriterier för en egenskap i taget,");
                explonationSB.AppendLine("och om du vill söka på en egenskap skriver du ett sökkriterium,");
                explonationSB.AppendLine("annars trycker du bara retur för att komma till nästa.");
                explonationSB.AppendLine("När alla egenskaper gåtts igenom så får du en sammanfattning av dina val");
                explonationSB.AppendLine("samt en möjlighet att utföra sökningen (J),");
                explonationSB.AppendLine("ändra på sökningen (N) eller ");
                explonationSB.Append("avbryta och återgå till huvudmenyn (A).\n");
                string explonationText = explonationSB.ToString();
                uI.Clear(); uI.WriteLine(explonationText);

                registrtion = uI.ReadLine(text: "Vad vill du söka efter på Registreringsnummer?:", verify: false).ToUpper()!;
                brand = uI.ReadLine(text: "Vad vill du söka efter på Märke?:", verify: false)!;
                model = uI.ReadLine(text: "Vad vill du söka efter på Modell?:", verify: false)!;
                sYear = uI.ReadLine(text: "Vad vill du söka efter på Årsmodell?:", verify: false)!;
                collor = uI.ReadLine(text: "Vad vill du söka efter på Färg?:", verify: false)!;
                sNrOfWheels = uI.ReadLine(text: "Vad vill du söka efter på Antal hjul?:", verify: false)!;

                uI.WriteLine("\nDu vill söka på:");
                if (string.IsNullOrWhiteSpace(registrtion)) { registrtion = null!; } else { uI.WriteLine($"Registretingsnummer:\t[{registrtion}]"); }
                if (string.IsNullOrWhiteSpace(brand)) { brand = null!; } else { uI.WriteLine($"Märke:\t[{brand}]"); }
                if (string.IsNullOrWhiteSpace(model)) { model = null!; } else { uI.WriteLine($"Modell:\t[{model}]"); }
                if (!int.TryParse(sYear, out int result1)) { year = null!; } else { year = result1; uI.WriteLine($"Årsmodell:\t[{year}]"); }
                if (string.IsNullOrWhiteSpace(collor)) { collor = null!; } else { uI.WriteLine($"Färg:\t[{collor}]"); }
                if (!int.TryParse(sNrOfWheels, out int result2)) { nrOfWheels = null!; } else { nrOfWheels = result2; uI.WriteLine($"Antal hjul:\t[{nrOfWheels}]"); }

                svar = uI.ReadLine("Stämmer det? (J/N/A)").ToUpper();
                if (svar.Contains('A')) { return; }
                if (svar.Contains('J')) { loop = false; }
            }
            // registrtion = "ABC123";
            bool gotIt = garageHandler.Find(registration: registrtion!,
                                            brand: brand!,
                                            model: model!,
                                            year: year!,
                                            collor: collor!,
                                            nrOfWheels: nrOfWheels!);
            if (!gotIt) { uI.WriteLine("Inga fordon machade din sökning."); }
            _ = uI.ReadLine(verify: false);
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
