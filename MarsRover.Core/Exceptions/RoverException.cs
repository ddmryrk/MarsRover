using System;
namespace MarsRover.Core.Exceptions
{
    public class RoverException : Exception
    {
        public RoverException(string message) : base(message) { }
    }
}
