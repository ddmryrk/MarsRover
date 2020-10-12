using MarsRover.Core.Models;

namespace MarsRover.Core.Interfaces
{
    public interface ICommandManager
    {
        public void AddCommands(string commandInput);
        public void ApplyCommands(uint roverId, Plateau plateau);
    }
}
