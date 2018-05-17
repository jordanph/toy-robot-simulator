using System;
using ToyRobotSimulator.Models;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class BoardTests
    {
        [Fact]
        public void WidthLessThanZero()
        {
            try
            {
                int width = 0;
                int height = 5;

                var board = new Board(width, height);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

            Assert.True(false, "Width cannot be less or equal to zero.");
        }

        [Fact]
        public void HeightLessThanZero()
        {
            try
            {
                int width = 5;
                int height = 0;

                var board = new Board(width, height);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

            Assert.True(false, "Height cannot be less or equal to zero.");
        }
    }
}
