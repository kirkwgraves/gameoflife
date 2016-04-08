using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CellGenerator
    {
        public List<Cell> GenerateCells()
        {
            var list = new List<Cell>();
            Random random = new Random();
            int randomCellNumber = random.Next(0, 100);
            list.AddRange(Enumerable.Repeat(new Cell(), randomCellNumber));
            return list;
        }
    }
}
