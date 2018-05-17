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

                var position = new Position(xPos, yPos);
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

                var position = new Position(xPos, yPos);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }

            Assert.True(false, "Y-Position cannot be less than zero.");
        }
    }
}
