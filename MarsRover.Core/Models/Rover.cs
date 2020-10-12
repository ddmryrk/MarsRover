using MarsRover.Core.Exceptions;
using MarsRover.Core.Services;
using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Core.Models
{
    public class Rover
    {
        public uint ID { get; private set; }
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }

        public Rover(uint id, Coordinate coordinate, Direction direction)
        {
            ID = id;
            Coordinate = coordinate;
            Direction = direction;
        }

        public Rover(uint id, string locationInput)
        {
            ID = id;

            var locationInputArray = locationInput.Split(' ');

            ControlRoverInputArrayLength(locationInputArray);
            SetCoordinateByRoverInputArray(locationInputArray);
            SetDirectionByRoverInputArray(locationInputArray);
        }

        public Rover GetClone()
        {
            var roverClone = (Rover)MemberwiseClone();
            roverClone.Coordinate = roverClone.Coordinate.GetClone();
            return roverClone;
        }

        public override string ToString() => $"{Coordinate.X} {Coordinate.Y} {Direction}";

        #region Private Methods
        private void ControlRoverInputArrayLength(string[] inputArray)
        {
            if (inputArray.Length < 3)
                throw new RoverException($"Start location length is not enough. Current length : {inputArray.Length}");
        }

        private void SetCoordinateByRoverInputArray(string[] inputArray)
        {
            if (!uint.TryParse(inputArray[0], out uint x))
                throw new CoordinateException($"Coordinate X is not valid. Current value : {inputArray[0]}");

            if (!uint.TryParse(inputArray[1], out uint y))
                throw new CoordinateException($"Coordinate Y is not valid. Current value : {inputArray[1]}");

            Coordinate = new Coordinate(x, y);
        }

        private void SetDirectionByRoverInputArray(string[] inputArray)
        {
            var directionManager = new DirectionManager();
            directionManager.SetDirection(inputArray[2]);

            Direction = directionManager.GetDirection();
        }
        #endregion
    }
}
