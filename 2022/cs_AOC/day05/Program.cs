namespace day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            var instructions = File.ReadAllText(file);

           
            string result = CrateRearrangementProcess.GetTopCratesAtferRearrangement(instructions,CrateRearrangementProcess.CraneType.CrateMover9000);
            Console.WriteLine("Part 1: Message = {0}",result);

            result = CrateRearrangementProcess.GetTopCratesAtferRearrangement(instructions, CrateRearrangementProcess.CraneType.CrateMover9001);
            Console.WriteLine("Part 1: Message = {0}", result);
        }




    }
}