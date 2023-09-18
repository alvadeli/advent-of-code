namespace day11
{
    internal class Program   
    {
        static void Main(string[] args)
        {
            string input = Utils.Input.GetInputFile();

            long monkeyBusines = KeepAway.Play(input, 20, true);
            Console.WriteLine("Part 1: Monkey Business = {0}", monkeyBusines);

            monkeyBusines = KeepAway.Play(input, 10000, false);
            Console.WriteLine("Part 2: Monkey Business = {0}", monkeyBusines);
        }
    }
}