using MarsRover.Core.Exceptions;
using MarsRover.Core.Interfaces;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Core.Services
{
    public class DirectionManager : IDirectionManager
    {
        private char _direction;

        public void SetDirection(string directionInput)
        {
            if (directionInput.Length > 1)
                throw new DirectionException("Direction length must be 1 character.");

            _direction = char.ToUpper(directionInput[0]);
        }

        public Direction GetDirection()
        {
            return _direction switch
            {
                'N' => Direction.N,
                'E' => Direction.E,
                'S' => Direction.S,
                'W' => Direction.W,
                _ => throw new DirectionException($"Undefined direction. Current direction : {_direction}"),
            };
        }
    }
}
