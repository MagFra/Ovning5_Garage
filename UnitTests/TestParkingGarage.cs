namespace UnitTests
{
    public class TestParkingGarage
    {
        [Fact]
        public void CreateGarage()
        {
            // Arrenge
            int expectedCapacity = 10;

            // Act
            ParkingGarage<IVehicle> garage = new(expectedCapacity);
            int actualCapacity = garage.Capacity;

            // Assert
            Assert.NotNull(garage);
            Assert.Equal(expectedCapacity, actualCapacity);
        }
        [Fact]
        public void ParkOneVehicleInGarage_WhenAllIsValid_ShouldEqual()
        {
            // Arrange
            IVehicle expectedVehicle = new Vehicle(registation: "ABC123",
                                              brand: "Volvo",
                                              model: "V70",
                                              year: 1996,
                                              collor: "Green",
                                              nrOfWheels: 4);
            ParkingGarage<IVehicle> garage = new(3);
            int expectedLengthBefore = 0;
            int expectedLengthAfter = 1;

            // Act
            int actualLengthBefore = garage.Length;
            garage.AddVehicle(expectedVehicle);
            int actualLengthAfter = garage.Length;
            IVehicle actualVehicle = garage.ByIndex(0);

            // Assert
            Assert.Equal(expectedLengthBefore, actualLengthBefore);
            Assert.Equal(expectedLengthAfter, actualLengthAfter);
            Assert.Equal(expectedVehicle, actualVehicle);
        }
        [Fact]
        public void TryToParkEmptyVehiclesInGarage_WhenVehicleIsNull_ShouldThrowException()
        {
            // Arrange
            IVehicle? testVehicle = null!;
            int expectedCapacity = 10;
            ParkingGarage<IVehicle> garage = new(expectedCapacity);

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => garage.AddVehicle(testVehicle));
            Assert.Equal("Value cannot be null. (Parameter 'vehicle')", ex.Message);
        }
        [Fact]
        public void TryToOverParkVehiclesInGarage_WhenGarageIsFull_ShouldThrowException()
        {
            // Arrange
            IVehicle testVehicle1 = new Vehicle(registation: "ABC123",
                                              brand: "Volvo",
                                              model: "V70",
                                              year: 1996,
                                              collor: "Green",
                                              nrOfWheels: 4);
            IVehicle testVehicle2 = new Vehicle(registation: "DEF456",
                                              brand: "Saab",
                                              model: "96",
                                              year: 1983,
                                              collor: "Red",
                                              nrOfWheels: 4);
            int Capacity = 1;
            ParkingGarage<IVehicle> garage = new(Capacity);

            if (garage.IsSpaceLeft) 
            { garage.AddVehicle(testVehicle1); } 
            else 
            { Assert.Fail("Garage is prematurely full!"); }

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => garage.AddVehicle(testVehicle2));
            Assert.Equal("This garage is full!", ex.Message);
        }
        [Fact]
        public void RemoveFirstParkedVehicleOfThreeIndex0_IsValid_ShouldSucceedWithEqual()
        {
            // Arrange
            IVehicle expetedVehicle1 = new Vehicle(registation: "ABC123",
                                              brand: "Volvo",
                                              model: "V70",
                                              year: 1996,
                                              collor: "Green",
                                              nrOfWheels: 4);
            IVehicle expetedVehicle2 = new Vehicle(registation: "DEF456",
                                              brand: "Saab",
                                              model: "96",
                                              year: 1983,
                                              collor: "Red",
                                              nrOfWheels: 4);
            IVehicle expetedVehicle3 = new Vehicle(registation: "GIH789",
                                              brand: "Fiat",
                                              model: "Uno",
                                              year: 1983,
                                              collor: "Blue",
                                              nrOfWheels: 4);
            int Capacity = 10;
            ParkingGarage<IVehicle> garage = new(Capacity);
            garage.AddVehicle(expetedVehicle1);
            garage.AddVehicle(expetedVehicle2);
            garage.AddVehicle(expetedVehicle3);
            int expetedLengthBefore = 3, expetedLengthAfter = 2, index = 0;

            // Act
            int actualLengthBefore = garage.Length;
            var result = garage.RemoveVehicleByIndex(index);
            int actualLengthAfter = garage.Length;
            IVehicle actualVehicle2 = garage.ByIndex(0);
            IVehicle actualVehicle3 = garage.ByIndex(1);


            // Assert
            Assert.True(result);
            Assert.Equal(expetedLengthBefore, actualLengthBefore);
            Assert.Equal(expetedLengthAfter, actualLengthAfter);
            Assert.Equal(expetedVehicle2, actualVehicle2);
            Assert.Equal(expetedVehicle3, actualVehicle3);
        }
        [Fact]
        public void RemoveLastParkedVehicleOfThreeIndex2_IsValid_ShouldSucceedWithEqual()
        {
            // Arrange
            IVehicle expetedVehicle1 = new Vehicle(registation: "ABC123",
                                              brand: "Volvo",
                                              model: "V70",
                                              year: 1996,
                                              collor: "Green",
                                              nrOfWheels: 4);
            IVehicle expetedVehicle2 = new Vehicle(registation: "DEF456",
                                              brand: "Saab",
                                              model: "96",
                                              year: 1983,
                                              collor: "Red",
                                              nrOfWheels: 4);
            IVehicle expetedVehicle3 = new Vehicle(registation: "GIH789",
                                              brand: "Fiat",
                                              model: "Uno",
                                              year: 1983,
                                              collor: "Blue",
                                              nrOfWheels: 4);
            int Capacity = 10;
            ParkingGarage<IVehicle> garage = new(Capacity);
            garage.AddVehicle(expetedVehicle1);
            garage.AddVehicle(expetedVehicle2);
            garage.AddVehicle(expetedVehicle3);
            int expetedLengthBefore = 3, expetedLengthAfter = 2, index = 2;

            // Act
            int actualLengthBefore = garage.Length;
            var result = garage.RemoveVehicleByIndex(index);
            int actualLengthAfter = garage.Length;
            IVehicle actualVehicle1 = garage.ByIndex(0);
            IVehicle actualVehicle2 = garage.ByIndex(1);


            // Assert
            Assert.True(result);
            Assert.Equal(expetedLengthBefore, actualLengthBefore);
            Assert.Equal(expetedLengthAfter, actualLengthAfter);
            Assert.Equal(expetedVehicle1, actualVehicle1);
            Assert.Equal(expetedVehicle2, actualVehicle2);
        }
        [Fact]
        public void RemoveMiddleParkedVehicleOfThreeIndex1_IsValid_ShouldSucceedWithEqual()
        {
            // Arrange
            IVehicle expetedVehicle1 = new Vehicle(registation: "ABC123",
                                              brand: "Volvo",
                                              model: "V70",
                                              year: 1996,
                                              collor: "Green",
                                              nrOfWheels: 4);
            IVehicle expetedVehicle2 = new Vehicle(registation: "DEF456",
                                              brand: "Saab",
                                              model: "96",
                                              year: 1983,
                                              collor: "Red",
                                              nrOfWheels: 4);
            IVehicle expetedVehicle3 = new Vehicle(registation: "GIH789",
                                              brand: "Fiat",
                                              model: "Uno",
                                              year: 1983,
                                              collor: "Blue",
                                              nrOfWheels: 4);
            int Capacity = 10;
            ParkingGarage<IVehicle> garage = new(Capacity);
            garage.AddVehicle(expetedVehicle1);
            garage.AddVehicle(expetedVehicle2);
            garage.AddVehicle(expetedVehicle3);
            int expetedLengthBefore = 3, expetedLengthAfter = 2, index = 1;

            // Act
            int actualLengthBefore = garage.Length;
            var result = garage.RemoveVehicleByIndex(index);
            int actualLengthAfter = garage.Length;
            IVehicle actualVehicle1 = garage.ByIndex(0);
            IVehicle actualVehicle3 = garage.ByIndex(1);


            // Assert
            Assert.True(result);
            Assert.Equal(expetedLengthBefore, actualLengthBefore);
            Assert.Equal(expetedLengthAfter, actualLengthAfter);
            Assert.Equal(expetedVehicle1, actualVehicle1);
            Assert.Equal(expetedVehicle3, actualVehicle3);
        }
    }
}