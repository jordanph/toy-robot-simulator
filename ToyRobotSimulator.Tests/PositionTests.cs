using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Models;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class PositionTests
    {
        [Fact]
        public void WidthLessThanZero()
        {
            try
            {
                int xPos = -1;
                int yPos = 5;

                var position = new Position(xPos, yPos, Direction.North);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

            Assert.True(false, "X-Position cannot be less than zero.");
        }

        [Fact]
        public void HeightLessThanZero()
        {
            try
            {
                int xPos = 5;
                int yPos = -1;

                var position = new Position(xPos, yPos, Direction.North);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

            Assert.True(false, "Y-Position cannot be less than zero.");
        }

        [Fact]
        public void LeftRotation()
        {
            var position = new Position(0, 0, Direction.North);

            position.Left();
            Assert.True(position.Direction == Direction.West);

            position.Left();
            Assert.True(position.Direction == Direction.South);

            position.Left();
            Assert.True(position.Direction == Direction.East);

            position.Left();
            Assert.True(position.Direction == Direction.North);
        }

        [Fact]
        public void RightRotation()
        {
            var position = new Position(0, 0, Direction.North);

            position.Right();
            Assert.True(position.Direction == Direction.East);

            position.Right();
            Assert.True(position.Direction == Direction.South);

            position.Right();
            Assert.True(position.Direction == Direction.West);

            position.Right();
            Assert.True(position.Direction == Direction.North);
        }

        [Fact]
        public void Move()
        {
            var position = new Position(0, 0, Direction.North);

            var newPosition = position.Move();
            Assert.True(newPosition.YPosition == 1 && newPosition.XPosition == 0);

            position = new Position(0, 0, Direction.East);

            newPosition = position.Move();
            Assert.True(newPosition.YPosition == 0 && newPosition.XPosition == 1);

            position = new Position(0, 0, Direction.South);

            newPosition = position.Move();
            Assert.True(newPosition.YPosition == -1 && newPosition.XPosition == 0);

            position = new Position(0, 0, Direction.West);

            newPosition = position.Move();
            Assert.True(newPosition.YPosition == 0 && newPosition.XPosition == -1);
        }
    }
}
