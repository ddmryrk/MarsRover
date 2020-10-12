using System.Collections.Generic;
using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces;
using MarsRover.Core.Models;
using MarsRover.Core.Models.Commands;

namespace MarsRover.Core.Services
{
    public class CommandManager : ICommandManager
    {
        public List<ICommand> CommandList = new List<ICommand>();

        public void AddCommands(string commandInput)
        {
            var commandArray = commandInput.ToUpper().ToCharArray();

            foreach (var commandAsChar in commandArray)
            {
                CommandList.Add(GetCommandByChar(commandAsChar));
            }
        }

        public void ApplyCommands(uint roverId, Plateau plateau)
        {
            var rover = plateau.GetRoverById(roverId);
            foreach (var command in CommandList)
            {
                var coordinateToMove = command.GetCoordinateToMove(rover);

                ControlBeforeApply(plateau, rover.Coordinate, coordinateToMove);

                command.Apply(rover);
            }
        }

        #region Private methods
        private ICommand GetCommandByChar(char character)
        {
            return character switch
            {
                'L' => new TurnLeft(),
                'R' => new TurnRight(),
                'M' => new Move(),
                _ => throw new CommandException("Undefined command."),
            };
        }

        private void ControlBeforeApply(Plateau plateau, Coordinate currentCoordinate, Coordinate coordinateToMove)
        {
            if (coordinateToMove.X != currentCoordinate.X || coordinateToMove.Y != currentCoordinate.Y)
                plateau.ControlCoordinatesToPlaceRover(coordinateToMove);
        }
        #endregion
    }
}
