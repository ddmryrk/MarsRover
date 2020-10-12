using Xunit;
using MarsRover.Core.Models;
using static MarsRover.Core.Constants.Constants;
using MarsRover.Core.Services;

namespace MarsRover.Tests
{
    public class DocumentCases
    {
        [Fact]
        public void DocumentTestCase1()
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(0, new Coordinate(1, 2), Direction.N);
            plateau.AddRover(rover);

            var commandManager = new CommandManager();
            commandManager.AddCommands("LMLMLMLMM");
            commandManager.ApplyCommands(0, plateau);

            Assert.Equal<uint>(1, rover.Coordinate.X);
            Assert.Equal<uint>(3, rover.Coordinate.Y);
            Assert.Equal(Direction.N, rover.Direction);
        }

        [Fact]
        public void DocumentTestCase2()
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(0, new Coordinate(3, 3), Direction.E);
            plateau.AddRover(rover);

            var commandManager = new CommandManager();
            commandManager.AddCommands("MMRMMRMRRM");
            commandManager.ApplyCommands(0, plateau);

            Assert.Equal<uint>(5, rover.Coordinate.X);
            Assert.Equal<uint>(1, rover.Coordinate.Y);
            Assert.Equal(Direction.E, rover.Direction);
        }
    }
}
