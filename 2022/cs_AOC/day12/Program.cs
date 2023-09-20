using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Utils;

namespace day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            var dijkstraInput = Area.CreateDijkstraInputFromFile(file);
            var steps = Area.GetShortesPathDijkstra(dijkstraInput.Grid, dijkstraInput.Start,dijkstraInput.End);
            Console.WriteLine("Part 1: Steps = {0}", steps);

            steps = Area.FindShortestPathFromA(dijkstraInput);
            Console.WriteLine("Part 2: Steps = {0}",steps);
        }
    }
}