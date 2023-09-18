namespace day03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            string[] rucksacks = File.ReadAllLines(file);
        
            int rucksacksPrioritySum = RucksackPriority.GetPrioritiesSum(rucksacks);
            Console.WriteLine("Part 1: Rucksacks Priority Sum= {0}", rucksacksPrioritySum);
    
            rucksacksPrioritySum = RucksackPriority.GetGroupPrioritiesSum(rucksacks);
            Console.WriteLine("Part 2: Rucksacks Priority Sum= {0}", rucksacksPrioritySum);
        }


    }  
}