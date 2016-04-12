using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class GameBoard
    {
        private List<string> _state;

        public int Width { get { return _state.Max(x => x.Length); } }
        public int Height { get { return _state.Count; } }

        public GameBoard(string state)
        {
            _state = state.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();  
        }

        public void Tick()
        {
            var newState = new List<string>();

            for (int y = 0; y < Height; y++)
            {
                var thisLine = "";
                for (int x = 0; x < Width; x++)
                {
                    thisLine += CalculateNewState(x, y);
                }
                newState.Add(thisLine);
            }

            _state = newState;
        }

        private char CalculateNewState(int x, int y)
        {
            var thisCell = _state[y][x];
            var neighbors = GetNeighbors(x, y).ToList();

            if (thisCell == 'D')
            {
                if (neighbors.Count(n => n == 'A') == 3)
                {
                    return 'A';
                }
            }

            if (thisCell == 'A')
            {
                if (neighbors.Count(n => n == 'A') < 2)
                {
                    return 'D';
                }

                else if (neighbors.Count(n => n == 'A') > 3)
                {
                    return 'D';
                }

                else if (neighbors.Count(n => n == 'A') == 2
                    || neighbors.Count(n => n == 'A') == 3)
                {
                    return 'A';
                }
            }

            return thisCell;
        }

        private IEnumerable<char> GetNeighbors(int x, int y)
        {
            var coords = new List<Coord>
            {

                new Coord(x, y-1),
                new Coord(x, y+1),

                new Coord(x+1, y-1),
                new Coord(x+1, y),
                new Coord(x+1, y+1),

                new Coord(x-1, y-1),
                new Coord(x-1, y),
                new Coord(x-1, y+1)
            };

            var neighbors = new List<char>();
            foreach (var pair in coords)
            {
                try
                {
                    var neighboringCell = _state[pair.Y][pair.X];
                    neighbors.Add(neighboringCell);
                }
                catch
                {
                    // No need for exception here
                }
            }

            return neighbors;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in _state)
            {
                sb.AppendLine(line);
            }
            return sb.ToString().Trim();
        }
    }
}