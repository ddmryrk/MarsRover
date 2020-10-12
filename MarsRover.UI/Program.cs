using System;
using MarsRover.Core.Constants;
using MarsRover.Core.Models;
using MarsRover.Core.Services;

namespace MarsRover.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var plateau = GetPlateau();

            for (uint roverId = 0; roverId < Constants.ROVER_COUNT; roverId++)
            {
                AddRover(roverId, plateau);
                ApplyCommands(roverId, plateau);
            }

            Print(plateau);

            Console.ReadLine();
        }

        private static Plateau GetPlateau()
        {
            var plateauSize = Console.ReadLine();
            var plateau = new Plateau(plateauSize);
            return plateau;
        }

        private static void AddRover(uint roverId, Plateau plateau)
        {
            var roverLocation = Console.ReadLine();

            var rover = new Rover(roverId, roverLocation);
            plateau.AddRover(rover);
        }

        private static void ApplyCommands(uint roverId, Plateau plateau)
        {
            var commandsInput = Console.ReadLine();

            var commandManager = new CommandManager();
            commandManager.AddCommands(commandsInput);
            commandManager.ApplyCommands(roverId, plateau);
        }

        private static void Print(Plateau plateau)
        {
            foreach (var rover in plateau.Rovers)
            {
                Console.WriteLine(rover.ToString());
            }
        }

    }
}
