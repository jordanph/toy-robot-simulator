using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{
    public class Robot
    {
        public Robot(Board board, Position position)
        {
            Board = board ?? throw new ArgumentNullException("Must pass in a valid board.");
            Position = position ?? throw new ArgumentNullException("Must pass in a valid position.");

            if (!Board.IsValidPosition(Position))
            {
                throw new InvalidOperationException("Position is off the board. You must pass in a valid position.");
            }

        }

        public Board Board { get; private set; }
        public Position Position { get; private set; }

        /// <summary>
        /// Rotates the robot 90 degress to the left.
        /// </summary>
        public void Left()
        {
            Position.Left();
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the right.
        /// </summary>
        public void Right()
        {
            Position.Right();
        }
    }
}
