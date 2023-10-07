using System.Text;

namespace Garage.UI
{
    public interface IMenuHandler
    {
        int RetrieveMenuChoice(StringBuilder menuStringBuilder, int nrOfChoices, int firstChois = 0);
    }
}