namespace day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile();
            var rounds = File.ReadAllLines(file);
    
            var result = Tournament.GetScoreAgainstOpponent(rounds.ToList());
            Console.WriteLine("Part 1: Score = {0}", result);

            result = Tournament.GetScoreFromMatchTarget(rounds.ToList());
            Console.WriteLine("Part 2: Score = {0}", result);
        }
    }
}