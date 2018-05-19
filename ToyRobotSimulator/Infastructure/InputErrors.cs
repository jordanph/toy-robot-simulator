using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Infastructure
{
    public static class InputErrors
    {
        public static string Help =
                        $@"Possible inputs:
- {ValidInputs.Place}: Places the robot on the table. The valid input for this action is: PLACE X-Position,Y-Position,Direction eg. PLACE 1,1,EAST
- {ValidInputs.Move}: Will move the robot one unit in the current direction it is facing
- {ValidInputs.Left}: Will rotate the robot 90 degrees to the left
- {ValidInputs.Right}: Will rotate the robot 90 degrees to the right
- {ValidInputs.Report}: Will print the current position of the robot (X-Position,Y-Position,Direction)
- {ValidInputs.Exit}: This input will exit the application
- {ValidInputs.Help}: This will display this current help menu";

        public static string InvalidPlace = $"Invalid position passed with the {ValidInputs.Place} command. Please ensure the format is in {ValidInputs.Place} xPosition,yPosition,direction.";

        public static string InvalidCommand(string command)
        {
            return $"Unknown input {command}. Please refer to the {ValidInputs.Help} option for a detailed list of the valid inputs.";
        }

        public static string InvalidMove(Robot robot)
        {
            return $"Cannot move robot from the position {robot.Position.XPosition},{robot.Position.YPosition} in the direction {robot.Position.Direction.ToString().ToUpper()} as position is off the table";
        }
        public static string RobotNotPlaced(string command) {
            return $"Invalid input {command}. Please ensure the robot has been placed on the board using the {ValidInputs.Place} command. Refer to {ValidInputs.Help} for more info.";
        }

    }
}