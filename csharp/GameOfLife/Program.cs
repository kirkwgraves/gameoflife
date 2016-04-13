using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialState = @"
---------+--++-++-+
+++-+---+--+--+--+-
+--+---+++--+--++-+
+---++-+----+++-+++
++-+---+-++-+++-+--
+-----+-+-+--+--+++
".Trim();

            var gameboard = new GameBoard(initialState, '+', '-');

            for (int i = 0; i <= 100; i++)
            {
                var output = gameboard.ToString();
                Console.Clear();
                Console.Write(output);

                Thread.Sleep(250);
                gameboard.Tick();
            }
        }                                     
    }
}
                                                      