using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Core.Models.Commands
{
    public class TurnRight : ICommand
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
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new DirectionException($"Undefined direction. {direction}"),
            };
        }
        #endregion
    }
}
