using System;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Infastructure
{
    public class InputProcessor
    {
        public InputProcessor(Robot robot, Board board)
        {
            Robot = robot;
            Board = board;
        }

        public Robot Robot { get; private set; }
        public Board Board { get; private set; }

        public string ProcessInput(string userInput)
        {
            var command = userInput.Split(" ")[0].ToUpper();

            if (string.IsNullOrWhiteSpace(command))
            {
                return null;
            }

            switch (command)
            {
                case ValidInputs.Place:
                    try
                    {
                        var position = userInput.Split(" ")[1].Split(",");

                        var xPos = Convert.ToInt32(position[0]);
                        var yPos = Convert.ToInt32(position[1]);
                        var direction = Enum.Parse<Direction>(position[2], true);

                        var placePosition = new Position(xPos, yPos, direction);

                        Robot = new Robot(Board, placePosition);

                        return null;
                    }
                    catch (InvalidOperationException e)
                    {
                        return e.Message;
                    }
                    catch 
                    {
                        return InputErrors.InvalidPlace;
                    }
                case ValidInputs.Move:
                    var validMove = Robot.Move();
                    if (!validMove)
                    {
                        return InputErrors.InvalidMove(Robot);
                    }
                    else
                    {
                        return null;
                    }
                case ValidInputs.Left:
                    Robot.Left();
                    return null;
                case ValidInputs.Right:
                    Robot.Right();
                    return null;
                case ValidInputs.Report:
                    return Robot.Report();
                case ValidInputs.Help:
                    return InputErrors.Help;
                case ValidInputs.Exit:
                    return "EXIT";
                default:
                    return InputErrors.InvalidCommand(command);
            }
        }
    }
}
