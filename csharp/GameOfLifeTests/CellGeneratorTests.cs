using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTests
{
    [TestClass]
    public class CellGeneratorTests
    {
        
        [TestMethod]
        public void GenerateCells_GivenInstantiation_RandomCellsPopulate()
        {
            var generator = new CellGenerator();

            var cells = generator.GenerateCells();

            Assert.IsTrue(cells.Count > 0 && cells.Count < 100);
        }
    }
}
