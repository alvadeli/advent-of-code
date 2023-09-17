using System.Collections;

namespace day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(false);

            var cpu = new CPU();
            int signalStrength = cpu.SignalStrengthSum(file);
            Console.WriteLine("Part 1: Signal Strength Sum: {0}", signalStrength);

            Console.WriteLine("Part 2: CRT Display");
            var crt = new CRT();
            Console.WriteLine(crt.GetImage(file));

        }
    }

 
}