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
    }
}
