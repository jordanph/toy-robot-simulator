using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{
    public class Board
    {
        public Board(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Both width and height values must be greater than 0.");
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        //  Checks to see if position is valid on the board
        //  - Cannot be less than 0
        //  - Cannot be greater or equal to board height/width
        public bool IsValidPosition(Position newPosition)
        {
            if (newPosition.XPosition >= Width || newPosition.YPosition >= Height)
            {
                return false;
            }

            if (newPosition.XPosition < 0 || newPosition.YPosition < 0)
            {
                return false;
            }

            return true;
        }
    }
}
