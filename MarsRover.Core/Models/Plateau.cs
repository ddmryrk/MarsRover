using System.Linq;
using System.Collections.Generic;
using MarsRover.Core.Exceptions;

namespace MarsRover.Core.Models
{
    public class Plateau
    {
        public Coordinate SizeCoordinate { get; private set; }
        public List<Rover> Rovers { get; private set; }

        public Plateau(uint sizeX, uint sizeY)
        {
            SizeCoordinate = new Coordinate(sizeX, sizeY);

            Rovers = new List<Rover>();
        }

        public Plateau(string sizeInput)
        {
            var sizes = sizeInput.Split(' ');

            ControlPlateauSizeInputArrayLength(sizes);
            SetSizeByPlateauSizeInputArray(sizes);

            Rovers = new List<Rover>();
        }

        public void AddRover(Rover rover)
        {
            ControlCoordinatesToPlaceRover(rover.Coordinate);

            Rovers.Add(rover);
        }

        public Rover GetRoverById(uint id)
        {
            var rover = Rovers.FirstOrDefault(r => r.ID == id);

            if (rover == null)
                throw new PlateauException($"Rover couldn't found. ID : {id}");

            return rover;
        }

        public void ControlCoordinatesToPlaceRover(Coordinate coordinate)
        {
            if (coordinate.X < 0 || coordinate.Y < 0)
                throw new PlateauException($"Coordinate must be positive number. Current position : {coordinate}");

            if (coordinate.X > SizeCoordinate.X || coordinate.Y > SizeCoordinate.Y)
                throw new PlateauException($"Rover must be inside of plateau. Current position : {coordinate}");

            if (IsRoverExistsForCoordinate(coordinate))
                throw new PlateauException($"There is another rover. Current position : {coordinate}");
        }

        #region Private Methods
        private void ControlPlateauSizeInputArrayLength(string[] inputArray)
        {
            if (inputArray.Length != 2)
                throw new PlateauException($"Size input length is not enough. Current length : {inputArray.Length}");
        }

        private void SetSizeByPlateauSizeInputArray(string[] inputArray)
        {
            if (!uint.TryParse(inputArray[0], out uint x))
                throw new PlateauException($"Size X is not valid. Current value : {inputArray[0]}");

            if (!uint.TryParse(inputArray[1], out uint y))
                throw new PlateauException($"Size Y is not valid. Current value : {inputArray[1]}");

            SizeCoordinate = new Coordinate(x, y);
        }

        private bool IsRoverExistsForCoordinate(Coordinate coordinate)
            => Rovers.Any(r => r.Coordinate.X == coordinate.X && r.Coordinate.Y == coordinate.Y);
        #endregion
    }
}