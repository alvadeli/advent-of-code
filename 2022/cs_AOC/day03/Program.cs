namespace day03
{
    internal class Program
    {
        public static bool demo = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);
            string[] rucksacks = File.ReadAllLines(file);
        
            int rucksacksPrioritySum = RucksackPriority.GetPrioritiesSum(rucksacks);
            Console.WriteLine("Part 1: Rucksacks Priority Sum= {0}", rucksacksPrioritySum);
    
            rucksacksPrioritySum = RucksackPriority.GetGroupPrioritiesSum(rucksacks);
            Console.WriteLine("Part 2: Rucksacks Priority Sum= {0}", rucksacksPrioritySum);
        }


    }  
}