using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Core.Models.Commands
{
    public class Move : ICommand
    {
        public void Apply(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Coordinate.IncreaseY();
                    break;
                case Direction.E:
                    rover.Coordinate.IncreaseX();
                    break;
                case Direction.S:
                    rover.Coordinate.DecreaseY();
                    break;
                case Direction.W:
                    rover.Coordinate.DecreaseX();
                    break;
                default:
                    throw new DirectionException($"Undefined direction. {rover.Direction}");
            }
        }

        public Coordinate GetCoordinateToMove(Rover rover)
        {
            var clone = rover.GetClone();

            Apply(clone);

            return clone.Coordinate;
        }
    }
}
