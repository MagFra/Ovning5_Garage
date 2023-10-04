using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class TestParkingGarage
    {
        [Fact]
        public void Test1()
        {
            ParkingGarage<IVehicle> garage = new(3);
            Assert.NotNull(garage);
            garage.AddVehicle(new Vehicle("ABC123","Volvo","V70",1996,"Green",4));
            int temp = garage.Length();
            Assert.Equal(3, temp);
        }
    }
}
