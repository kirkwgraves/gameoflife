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
        public void Tick_CellsAreAllDead_NoCellsLive()
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
AADD
DDDD
DDDD".Trim());

            // Act
            gameboard.Tick();
            var expected = @"
AADD
AADD
DDDD
DDDD".Trim();
            // Assert
            Assert.AreEqual(gameboard.ToString(), expected);
        }

        [TestMethod]
        public void Tick_LivingCellWith1LivingNeighbor_CellDies()
        {
            //Arrange
            var gameboard = new GameBoard(@"
ADDD
DDDD
DDDD
DDDD".Trim());

            //Act
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
        public void Tick_LivingCellWithMoreThan3Neighbors_CellDies()
        {
            // Arrange
            var gameboard = new GameBoard(@"
AAAD
AADD
DDDD
DDDD".Trim());

            // Act
            gameboard.Tick();
            var expected = @"
ADAD
ADAD
DDDD
DDDD".Trim();

            // Assert 
            Assert.AreEqual(gameboard.ToString(), expected);        
        }

        [TestMethod]
        public void Tick_LivingCellWith2LivingNeighbors_CellLives()
        {
            // Arrange
            var gameboard = new GameBoard(@"
DDDD
DAAD
DDAD
DDDD".Trim());

            // Act
            gameboard.Tick();
            var expected = @"
DDDD
DAAD
DAAD
DDDD".Trim();

            // Assert
            Assert.AreEqual(gameboard.ToString(), expected);
        }

        [TestMethod]
        public void Tick_LivingCellWith3LivingNeighbors_CellLives()
        {
            // Arrange
            var gameboard = new GameBoard(@"
DADD
AAAD
DDDD
DDDD".Trim());

            // Act
            gameboard.Tick();
            var expected = @"
AAAD
AAAD
DADD
DDDD".Trim();

            // Assert
            Assert.AreEqual(gameboard.ToString(), expected);
        }
    }
}
