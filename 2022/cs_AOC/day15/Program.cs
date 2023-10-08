using Utils;

namespace day15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = Utils.Input.GetInputFile();
            HashSet<PointL> coveredByBeacon = SignalArea.GetCoveredPositions(file, 2000000);
            Console.WriteLine("Part 1: Positioncount: {0}", coveredByBeacon.Count);
        }
    }
}