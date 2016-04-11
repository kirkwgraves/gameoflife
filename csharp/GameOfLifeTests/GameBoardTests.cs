using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameBoardTests
    {
        [TestMethod]
        public void Ctor_GivenState_SplitsRepresentationIntoModel()
        {
            // Arrange
            var initialState = @"
AD
DD".Trim();
            // Act
            var gameboard = new GameBoard(initialState);


            // Assert
            Assert.AreEqual(gameboard.Width, 2);
            Assert.AreEqual(gameboard.Height, 2);
        }


        [TestMethod]
        public void Ctor_Given5X5Board_WidthAndHeightSet()
        {
            // Arrange
            var initialState = @"
ADDDD
DDDDD
DDDDD
DDDDD
DDDDD".Trim();
            // Act
            var gameboard = new GameBoard(initialState);

            // Assert
            Assert.AreEqual(gameboard.Width, 5);
            Assert.AreEqual(gameboard.Height, 5);
        }

        [TestMethod]
        public void Tick_CellsAreAllDead_NothingLives()
        {
            // Arrange
            var gameboard = new GameBoard(@"
DDDD
DDDD
DDDD
DDDD".Trim());
            // Act
            gameboard.Tick();
            var expected = @"
DDDD
DDDD
DDDD
DDDD".Trim();
            // Assert
            Assert.AreEqual(gameboard.ToString(), expected);
        }

        [TestMethod]
        public void Tick_DeadCellHasThreeLivingNeighbors_CellComesToLife()
        {
            // Arrange
            var gameboard = new GameBoard(@"
DADD
ADAD
DDDD
DDDD".Trim());

            // Act
            gameboard.Tick();
            var expected = @"
DADD
AAAD
DDDD
DDDD".Trim();
            // Assert
            Assert.AreEqual(gameboard.ToString(), expected);
        }
    }
}
