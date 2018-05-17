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
                var position = new Position(0, 0);

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
                var position = new Position(width + 1, height + 1);

                var robot = new Robot(board, position);
            }
            catch (InvalidOperationException e)
            {
                return;
            }

            Assert.True(false, "Must pass in a position that isn't off the board.");
        }

    }
}
