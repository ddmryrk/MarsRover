using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Core.Models.Commands
{
    public class TurnLeft : ICommand
    {
        public void Apply(Rover rover)
        {
            rover.Direction = GetNewDirection(rover.Direction);
        }

        public Coordinate GetCoordinateToMove(Rover rover) => rover.Coordinate;

        #region Private Methods
        private Direction GetNewDirection(Direction direction)
        {
            return direction switch
            {
                Direction.N => Direction.W,
                Direction.E => Direction.N,
                Direction.S => Direction.E,
                Direction.W => Direction.S,
                _ => throw new DirectionException($"Undefined direction. {direction}"),
            };
        }
        #endregion
    }
}