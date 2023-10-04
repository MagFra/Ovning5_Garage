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
            // Arrange
            IVehicle expectedVehicle = new Vehicle(registation: "ABC123",
                                              brand: "Volvo",
                                              model: "V70",
                                              year: 1996,
                                              collor: "Green",
                                              nrOfWheels: 4);

            ParkingGarage<IVehicle> garage = new(3);

            // Assert.NotNull(garage);

            int expectedBefore = 0;
            int expectedAfter = 1;

            // Act
            int actualBefore = garage.Length();
            garage.AddVehicle(expectedVehicle);
            int actualAfter = garage.Length();
            IVehicle actualVehicle = garage.ByIndex(0);

            // Assert
            Assert.Equal(expectedBefore, actualBefore);
            Assert.Equal(expectedAfter, actualAfter);
            Assert.Equal(expectedVehicle, actualVehicle);
        }
    }
}
