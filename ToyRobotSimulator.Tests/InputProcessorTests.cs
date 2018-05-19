using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.Infastructure;
using ToyRobotSimulator.Models;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class InputProcessorTests
    {
        public InputProcessorTests()
        {
            Board = new Board(BoardWidth, BoardHeight);
        }

        public Board Board { get; set; }
        public Robot Robot { get; set; }
        private const int BoardWidth = 5;
        private const int BoardHeight = 5;

        [Fact]
        public void InvalidCommand()
        {
            var inputProcessor = new InputProcessor(Robot, Board);

            var invalidCommand = "INVALIDINPUT";

            Assert.Equal(inputProcessor.ProcessInput(invalidCommand), InputErrors.InvalidCommand(invalidCommand));
        }

        [Fact]
        public void InvalidPlaceCommandArugments()
        {
            var inputProcessor = new InputProcessor(Robot, Board);

            var placeCommand = $"{ValidInputs.Place} 1,G,East";

            Assert.Equal(inputProcessor.ProcessInput(placeCommand), InputErrors.InvalidPlace);

            Assert.True(inputProcessor.Robot == null); // Robot should not have been initialised as it wasn't placed
        }

        [Fact]
        public void PlacePositionCommandOffBoard()
        {
            var inputProcessor = new InputProcessor(Robot, Board);

            var placeCommand = $"{ValidInputs.Place} 1,{Board.Height},{Direction.East.ToString()}";

            Assert.Equal(inputProcessor.ProcessInput(placeCommand), $"Position is off the board. Please ensure the xPosition is between 0 and {Board.Width - 1}, and the yPosition is between 0 and {Board.Height - 1}.");

            Assert.True(inputProcessor.Robot == null); // Robot should not have been initialised as it wasn't placed
        }

        [Fact]
        public void HelpCommandCalled()
        {
            var inputProcessor = new InputProcessor(Robot, Board);

            Assert.Equal(inputProcessor.ProcessInput(ValidInputs.Help), InputErrors.Help);
        }

        [Fact]
        public void ExitCommandCalled()
        {
            var inputProcessor = new InputProcessor(Robot, Board);

            Assert.Equal(inputProcessor.ProcessInput(ValidInputs.Exit), ValidInputs.Exit);
        }

        [Fact]
        public void RobotFallsOffBoard()
        {
            var inputProcessor = new InputProcessor(Robot, Board);

            var placeCommand = $"{ValidInputs.Place} 0,0,{Direction.South.ToString()}";

            inputProcessor.ProcessInput(placeCommand);

            var moveCommand = ValidInputs.Move;

            Assert.Equal(inputProcessor.ProcessInput(moveCommand), InputErrors.InvalidMove(inputProcessor.Robot));
        }
    }
}
