using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Utils.Input.GetInputFile();
            
            var cave = Cave.CreateFromFile(input);      
            int sandUnits = cave.ProduceSand();
            Console.WriteLine("Part 1: SandUnits={0}", sandUnits);

            var caveWithFloor = Cave.CreateWithFloorFromFile(input);
            sandUnits = caveWithFloor.ProduceSand();
            Console.WriteLine("Part 2: SandUnits={0}", sandUnits);

        }
    }





}