using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        private readonly CellGenerator _generator;
        public int Height { get; private set; }
        public int Width { get; private set; }
        public IList<List<Cell>> Rows { get; set; }

        public World(int width, int height, CellGenerator generator = null)
        {
            _generator = generator ?? new CellGenerator();
            this.Width = width;
            this.Height = height;

            GenerateState();
        }
        
        private void GenerateState()
        {  
            Rows = new List<List<Cell>>();
            for (int y = 0; y < Height; y++)
            {
                var row = new List<Cell>();
                for (int x = 0; x < Width; x++)
                {
                    var cell = GenerateInitialState();
                    row.Add(cell);
                }
                Rows.Add(row);
            }
        }

        private static Cell GenerateInitialState()
        {
            return new Cell();
        }

    }

 
}
