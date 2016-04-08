using System;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void NewWorld_GivenDimensions_IsNotNull()
        {
            var world = new World(30, 30);

            Assert.IsNotNull(world);
            Assert.AreEqual(world.Width, 30);
            Assert.AreEqual(world.Height, 30);
        }

        [TestMethod]
        public void NewWorld_GivenDimensions_RowsAreNotNull()
        {
            var world = new World(30, 30);

            Assert.IsNotNull(world);
            Assert.AreEqual(world.Rows.Count, 30);
            Assert.AreEqual(world.Rows[0].Count, 30);
        }

        [TestMethod]
        public void NewWorld_GivenDimensions_CellsPopulated()
        {
            var world = new World(1, 1);
            var cell = world.Rows[0][0];

            Assert.IsInstanceOfType(cell, typeof(Cell));
        }

        [TestMethod]
        public void GenerateCells_GivenInstantiation_RandomCellsPopulate()
        {
            var generator = new CellGenerator();

            var cells = generator.GenerateCells();

            Assert.IsTrue(cells.Count > 0 && cells.Count < 100 );
        }

    }

    
    
}
