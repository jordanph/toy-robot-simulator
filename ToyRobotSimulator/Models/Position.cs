using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{
    public class Position
    {
        public Position(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException("Both x and y positions must be greater or equal than 0.");
            }

            XPosition = x;
            YPosition = y;
        }

        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public override string ToString()
        {
            return $"{XPosition},{YPosition}";
        }
    }
}
