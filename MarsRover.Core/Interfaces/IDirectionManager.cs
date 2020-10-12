using static MarsRover.Core.Constants.Constants;

namespace MarsRover.Core.Interfaces
{
    public interface IDirectionManager
    {
        public void SetDirection(string directionInput);
        public Direction GetDirection();
    }
}
