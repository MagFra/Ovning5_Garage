using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace UnitTests.Vehicles
{
    public class TestVehicle
    {
        [Fact]
        public void CreateVehicle_WhenAllIsValid_ShouldEqual()
        {
            // Create a "fixed" vehicle and verrify it returns set properties.
            // Arrange
            string expectedRegistration = "ABC123";
            string expectedBrand = "Volvo";
            string expectedModel = "V70";
            int expectedYear = 98;
            string expectedCollor = "Red";
            int expectedNrOfWheels = 4;
            var vehicle = new Vehicle(registation: expectedRegistration,
                                      brand: expectedBrand,
                                      model: expectedModel,
                                      year: expectedYear,
                                      collor: expectedCollor,
                                      nrOfWheels: expectedNrOfWheels);

            // Act
            string actualRegistration = vehicle.Registration;
            string actualBrand = vehicle.Brand;
            string actualModel = vehicle.Model;
            int actualYear = vehicle.Year;
            string actualCollor = vehicle.Collor;
            int actualNrOfWheels = vehicle.NrOfWheels;

            // Assert
            Assert.Equal(expectedRegistration, actualRegistration);
            Assert.Equal(expectedBrand, actualBrand);
            Assert.Equal(expectedModel, actualModel);
            Assert.Equal(expectedYear, actualYear);
            Assert.Equal(expectedCollor, actualCollor);
            Assert.Equal(expectedNrOfWheels, actualNrOfWheels);

            // Clean
            vehicle = null;
            GC.Collect();

        }

        [Fact]
        public void CreateVehicle_WhenInvalidRegistrationIsNull_ShouldThrowException()
        {
            // Try to create a Vehicle whith Registration as Null.
            // Arrange
            string? expectedRegistration = null!;
            string expectedBrand = "Volvo";
            string expectedModel = "V70";
            int expectedYear = 98;
            string expectedCollor = "Red";
            int expectedNrOfWheels = 4;

            // Act
            Vehicle vehicle = new Vehicle(registation: expectedRegistration,
                                      brand: expectedBrand,
                                      model: expectedModel,
                                      year: expectedYear,
                                      collor: expectedCollor,
                                      nrOfWheels: expectedNrOfWheels);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>();

        }
    }
}


/*
CreateVehicle_WhenAllIsValid_ShouldEqual
CreateVehicle_WhenInvalidRegistrationIsNull_ShouldThrowException
CreateVehicle_WhenInvalidBrandIsNull_ShouldThrowException
CreateVehicle_WhenInvalidModelIsNull_ShouldThrowException
CreateVehicle_WhenInvalidYearIsNegative_ShouldThrowException
CreateVehicle_WhenInvalidCollorIsNull_ShouldThrowException
CreateVehicle_WhenInvalidNrOfWheelsIsNegative_ShouldThrowException
*/