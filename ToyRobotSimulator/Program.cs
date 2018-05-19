using System;
using ToyRobotSimulator.Infastructure;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator
{
    public class Program
    {
        private const int BoardWidth = 5;
        private const int BoardHeight = 5;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the toy robot simulator!");
            Console.WriteLine($"To get started, please place the robot on the {BoardWidth}x{BoardHeight} board using PLACE x-positon,y-position,direction.");
            Console.WriteLine($"Please use the HELP option at any time to see the valid inputs or EXIT to close the application.");
            Console.WriteLine();

            Board board = new Board(BoardWidth, BoardHeight);
            Robot robot = null;
            InputProcessor inputProcessor = new InputProcessor(robot, board);

            bool exitApplication = false;

            while(!exitApplication)
            {
                var userInput = Console.ReadLine().Trim();

                var output = inputProcessor.ProcessInput(userInput);

                if (!string.IsNullOrWhiteSpace(output))
                {
                    if (output == ValidInputs.Exit)
                    {
                        exitApplication = true;
                    }

                    Console.WriteLine(output);
                }
            }
        }
    }
}