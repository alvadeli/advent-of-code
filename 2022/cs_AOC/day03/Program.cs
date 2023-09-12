namespace day03
{
    internal class Program
    {
        public static bool demo = false;
        public static bool firstPart = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);
            string[] rucksacks = File.ReadAllLines(file);

            int rucksacksPrioritySum;
            if (firstPart)
            {
                rucksacksPrioritySum = RucksackPriority.GetPrioritiesSum(rucksacks);
            } 
            else
            {
                rucksacksPrioritySum = RucksackPriority.GetGroupPrioritiesSum(rucksacks);
            }

            Console.WriteLine("Rucksacks Priority Sum: {0}", rucksacksPrioritySum);
        }


    }  
}