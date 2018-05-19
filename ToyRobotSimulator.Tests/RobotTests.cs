using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Models;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void MustPassNonNullBoard()
        {
            try
            {
                Board board = null;
                var position = new Position(0, 0, Direction.North);

                var robot = new Robot(board, position);
            }
            catch (ArgumentNullException e)
            {
                return;
            }

            Assert.True(false, "Must pass a non-null board into robot.");
        }

        [Fact]
        public void MustPassNonNullPosition()
        {
            try
            {
                var board = new Board(5, 5);

                Position position = null;

                var robot = new Robot(board, position);
            }
            catch (ArgumentNullException e)
            {
                return;
            }

            Assert.True(false, "Must pass a non-null board into robot.");
        }

        [Fact]
        public void MustPassValidPosition()
        {
            try
            {
                int height = 5;
                int width = 5;

                var board = new Board(width, height);
                var position = new Position(width + 1, height + 1, Direction.North);

                var robot = new Robot(board, position);
            }
            catch (InvalidOperationException e)
            {
                return;
            }

            Assert.True(false, "Must pass in a position that isn't off the board.");
        }

        [Fact]
        public void LeftRotation()
        {
            var position = new Position(0, 0, Direction.North);
            var board = new Board(5, 5);

            var robot = new Robot(board, position);

            robot.Left();
            Assert.True(position.Direction == Direction.West);

            robot.Left();
            Assert.True(position.Direction == Direction.South);

            robot.Left();
            Assert.True(position.Direction == Direction.East);

            robot.Left();
            Assert.True(position.Direction == Direction.North);
        }

        [Fact]
        public void RightRotation()
        {
            var position = new Position(0, 0, Direction.North);
            var board = new Board(5, 5);

            var robot = new Robot(board, position);

            robot.Right();
            Assert.True(position.Direction == Direction.East);

            robot.Right();
            Assert.True(position.Direction == Direction.South);

            robot.Right();
            Assert.True(position.Direction == Direction.West);

            robot.Right();
            Assert.True(position.Direction == Direction.North);
        }

        [Fact]
        public void FallOffBoardEast()
        {
            var height = 5;
            var width = 5;

            var board = new Board(width, height);
            var position = new Position(width - 1, height - 1, Direction.East);
            var robot = new Robot(board, position);

            Assert.False(robot.Move());
        }

        [Fact]
        public void FallOffBoardWest()
        {
            var height = 5;
            var width = 5;

            var board = new Board(width, height);
            var position = new Position(0, height - 1, Direction.West);
            var robot = new Robot(board, position);

            Assert.False(robot.Move());
        }

        [Fact]
        public void FallOffBoardNorth()
        {
            var height = 5;
            var width = 5;

            var board = new Board(width, height);
            var position = new Position(width - 1, height - 1, Direction.North);
            var robot = new Robot(board, position);

            Assert.False(robot.Move());
        }

        [Fact]
        public void FallOffBoardSouth()
        {
            var height = 5;
            var width = 5;

            var board = new Board(width, height);
            var position = new Position(width - 1, 0, Direction.South);
            var robot = new Robot(board, position);

            Assert.False(robot.Move());
        }

        [Fact]
        public void ReturnValidReportOfPosition()
        {
            var height = 5;
            var width = 5;

            var board = new Board(width, height);

            var xPos = 0;
            var yPos = 0;
            var direction = Direction.North;

            var position = new Position(xPos, yPos, direction);
            var robot = new Robot(board, position);

            Assert.True(robot.Report() == $"{xPos},{yPos},{direction.ToString().ToUpper()}");

            robot.Move();
            Assert.True(robot.Report() == $"{xPos},{yPos+1},{direction.ToString().ToUpper()}");

            robot.Right();
            robot.Move();
            Assert.True(robot.Report() == $"{xPos+1},{yPos+1},{Direction.East.ToString().ToUpper()}");
        }
    }
}
