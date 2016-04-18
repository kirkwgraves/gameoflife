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

        
        private char _alive;
        private char _dead;

        public int Width {
            get
            {
                // Width property is the maximum value of the string 
                return _state.Max(x => x.Length);
            }
        }

        public int Height {
            get
            {
                // Height property is the number of strings in the list
                return _state.Count;
            }
        }

        public GameBoard(string state, char alive = 'A', char dead = 'D')
        {
            // Initialize the state of the gameboard and alive/dead chars for 'cell' state within constructor
            _alive = alive;
            _dead = dead;
            // Convert the string 'state' variable into a List<string>
            _state = state.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();  
        }

        public void Tick()
        {
            // Initialize a new List<string> to contain new gameboard state
            var newState = new List<string>();
            
            // Loop through current state columns
            for (int y = 0; y < Height; y++)
            {
                var thisLine = "";
                // Loop through current state rows
                for (int x = 0; x < Width; x++)
                {
                    // Build new state through successive calls of CalculateNewState method passing in x and y
                    thisLine += CalculateNewState(x, y);
                }
                // Add lines to newState variable
                newState.Add(thisLine);
            }
            // Assign newState to current state
            _state = newState;
        }

        private object CalculateNewState(int x, int y)
        {
            var thisCell = _state[y][x];
            var neighbors = GetNeighbors(x, y).ToList();
            var livingNeighbors = neighbors.Count(n => n == _alive);

            if ((thisCell == _alive) && (livingNeighbors == 2 || livingNeighbors == 3))
            {
                return _alive;
            }

            else if (thisCell == _alive && livingNeighbors < 2)
            {
                return _dead;
            }

            else if (thisCell == _alive && livingNeighbors > 3)
            {
                return _dead;
            }

            else if (thisCell == _dead && livingNeighbors >= 3)
            {
                return _alive;
            }

            return thisCell;
        }

        private List<char> GetNeighbors(int x, int y)
        {
            // Assign list of coordinates to variable
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
                    // Assign state to each neighboring cell
                    var neighboringCell = _state[pair.Y][pair.X];
                    neighbors.Add(neighboringCell);
                }
                catch
                {
                    // Exception
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