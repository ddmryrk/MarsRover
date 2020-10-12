using MarsRover.Core.Models;

namespace MarsRover.Core.Interfaces
{
    public interface ICommand
    {
        void Apply(Rover rover);
        Coordinate GetCoordinateToMove(Rover rover);
    }
}
