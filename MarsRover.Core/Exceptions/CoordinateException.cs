using System;
namespace MarsRover.Core.Exceptions
{
    public class CoordinateException : Exception
    {
        public CoordinateException(string message) : base(message) { }
    }
}
