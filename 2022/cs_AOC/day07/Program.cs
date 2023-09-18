namespace day07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            string[] terminaloutput = System.IO.File.ReadAllLines(file);

            Directory topLevel = FileSystem.ReconstructDirectory(terminaloutput);

            int sum = FileSystem.GetDirSizeSum(topLevel);
            Console.WriteLine("Part 1: Directory Size = {0}", sum);

            int size = FileSystem.GetDirectorySizeToFreeDisk(topLevel);
            Console.WriteLine("Part 1: Directory Size to free disk = {0}", size);
        }
    }


}