using System;
namespace MarsRover.Core.Exceptions
{
    public class DirectionException : Exception
    {
        public DirectionException(string message) : base(message) { }
    }
}
