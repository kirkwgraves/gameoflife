using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CellGenerator
    {
        
        public List<char> GenerateCells(int numCellsToGenerate)
        {
            var half = numCellsToGenerate / 2;
            var list = new List<char>();

            list.AddRange(Enumerable.Repeat('A', half));
            list.AddRange(Enumerable.Repeat('D', half));

            while (list.Count != numCellsToGenerate)
            {
                list.Add('D');
            }

            return list.OrderBy(x => Guid.NewGuid()).ToList();

        }
    }
}
