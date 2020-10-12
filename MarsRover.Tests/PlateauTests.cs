using System;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Models;
using Xunit;

namespace MarsRover.Tests
{
    public class PlateauTests
    {
        [Fact]
        public void When_InputSizeIsNotValid_Expect_PlateauException()
        {
            var expectedErrorMessage = "Size input length is not enough. Current length : 3";

            var exception = Assert.Throws<PlateauException>(() => new Plateau("5 1 3"));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_InputXIsNotValid_Expect_PlateauException()
        {
            var expectedErrorMessage = "Size X is not valid. Current value : a";

            var exception = Assert.Throws<PlateauException>(() => new Plateau("a 1"));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_InputYIsNotValid_Expect_PlateauException()
        {
            var expectedErrorMessage = "Size Y is not valid. Current value : b";

            var exception = Assert.Throws<PlateauException>(() => new Plateau("1 b"));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_AddRover_RoverCoordinateIsTooMuch_Expect_PlateauException()
        {
            var expectedErrorMessage = "Rover must be inside of plateau. Current position : (9,2)";
            var plateau = new Plateau("5 5");
            var rover = new Rover(0, "9 2 N");

            var exception = Assert.Throws<PlateauException>(() => plateau.AddRover(rover));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_AddRover_AnotherRoverIsExist_Expect_PlateauException()
        {
            var expectedErrorMessage = "There is another rover. Current position : (4,2)";
            var plateau = new Plateau("5 5");
            var rover1 = new Rover(0, "4 2 N");
            var rover2 = new Rover(0, "4 2 N");
            plateau.AddRover(rover1);

            var exception = Assert.Throws<PlateauException>(() => plateau.AddRover(rover2));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}
