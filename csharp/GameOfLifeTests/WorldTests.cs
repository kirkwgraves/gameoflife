using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class WorldTests
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
        public void NewWorld_GivenDimensions_CellsPopulate()
        {
            var world = new World(1, 1);
            var cell = world.Rows[0][0];

            Assert.IsInstanceOfType(cell, typeof(Cell));
        }


       

        [TestMethod]
        public void Tick_GivenOneLivingNeighbor_CellDies()
        {
            var cells = new List<Cell>
            {
                new Cell {IsAlive = true }
            };
            var generator = new CellGenerator();
            var world = new World(1, 1, generator);

            world.Tick();

            Assert.IsFalse(world.Rows[0][0].IsAlive);
        }
    }

    
    
}
