using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotSimulator.Models
{
    public class Position
    {
        public Position(int x, int y, Direction direction)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException("Both x and y positions must be greater or equal than 0.");
            }

            XPosition = x;
            YPosition = y;
            Direction = direction;
        }

        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public Direction Direction { get; private set; }

        /// <summary>
        /// Rotates the position 90 degrees to the left.
        /// </summary>
        public void Left()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }

        /// <summary>
        /// Rotates the position 90 degrees to the right.
        /// </summary>
        public void Right()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    break;
            }
        }

        /// <summary>
        /// Moves the position forward by one depending on direction.
        /// </summary>
        public Position Move()
        {
            var newPosition = new Position(XPosition, YPosition, Direction);

            switch (Direction)
            {
                case Direction.North:
                    newPosition.YPosition++;
                    break;
                case Direction.East:
                    newPosition.XPosition++;
                    break;
                case Direction.South:
                    newPosition.YPosition--;
                    break;
                case Direction.West:
                    newPosition.XPosition--;
                    break;
            }

            return newPosition;
        }

        public override string ToString()
        {
            return $"{XPosition},{YPosition},{Direction.ToString().ToUpper()}";
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
