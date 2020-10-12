using MarsRover.Core.Exceptions;
using MarsRover.Core.Models;
using MarsRover.Core.Services;
using Xunit;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Tests
{
    public class CommandManagerTests
    {
        [Fact]
        public void When_AddInvalidCommand_Expect_CommandException()
        {
            var expectedErrorMessage = "Undefined command.";

            var commandManager = new CommandManager();

            var exception = Assert.Throws<CommandException>(() => commandManager.AddCommands("MLRMLRX"));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Theory]
        [InlineData("L", Direction.W)]
        [InlineData("LL", Direction.S)]
        [InlineData("LLL", Direction.E)]
        [InlineData("LLLL", Direction.N)]
        [InlineData("R", Direction.E)]
        [InlineData("RR", Direction.S)]
        [InlineData("RRR", Direction.W)]
        [InlineData("RRRR", Direction.N)]
        [InlineData("LR", Direction.N)]
        [InlineData("LRLR", Direction.N)]
        public void When_TurnCommandsApply_Expect_Success(string command, Direction expectedDirection)
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(0, new Coordinate(1, 2), Direction.N);
            plateau.AddRover(rover);

            var commandManager = new CommandManager();
            commandManager.AddCommands(command);
            commandManager.ApplyCommands(0, plateau);

            var result = plateau.GetRoverById(0).Direction;

            Assert.Equal(expectedDirection, result);
        }

        [Theory]
        [InlineData("LMLMLMLMM", Direction.N, 1, 3)]
        [InlineData("M", Direction.N, 1, 3)]
        [InlineData("MMR", Direction.E, 1, 4)]
        [InlineData("MMRMMR", Direction.S, 3, 4)]
        [InlineData("MMRMMRM", Direction.S, 3, 3)]
        [InlineData("MMRMMRMRR", Direction.N, 3, 3)]
        [InlineData("MMRMMRMRRM", Direction.N, 3, 4)]
        public void When_MoveCommandsApply_Expect_Success(string command, Direction expectedDirection, uint expectedX, uint expectedY)
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(0, new Coordinate(1, 2), Direction.N);
            plateau.AddRover(rover);

            var commandManager = new CommandManager();
            commandManager.AddCommands(command);
            commandManager.ApplyCommands(0, plateau);

            var result = plateau.GetRoverById(0);

            Assert.Equal(expectedDirection, result.Direction);
            Assert.Equal(expectedX, result.Coordinate.X);
            Assert.Equal(expectedY, result.Coordinate.Y);
        }

        [Fact]
        public void When_Move_AlreadyARover_Expect_PlateauError()
        {
            var expectedErrorMessage = "There is another rover. Current position : (1,2)";

            var plateau = new Plateau(5, 5);

            var rover = new Rover(0, new Coordinate(1, 2), Direction.N);
            plateau.AddRover(rover);

            var rover2 = new Rover(1, new Coordinate(0, 2), Direction.E);
            plateau.AddRover(rover2);

            var commandManager = new CommandManager();
            commandManager.AddCommands("M");

            var exception = Assert.Throws<PlateauException>(() => commandManager.ApplyCommands(1, plateau));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }

        [Fact]
        public void When_Move_OutsideOfMap_Expect_PlateauError()
        {
            var expectedErrorMessage = "Rover must be inside of plateau. Current position : (5,6)";

            var plateau = new Plateau(5, 5);

            var rover = new Rover(0, new Coordinate(5, 4), Direction.N);
            plateau.AddRover(rover);

            var commandManager = new CommandManager();
            commandManager.AddCommands("MM");

            var exception = Assert.Throws<PlateauException>(() => commandManager.ApplyCommands(0, plateau));

            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }
}
