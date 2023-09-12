namespace day02
{
    internal class Program
    {
        public static bool demo = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);

            var rounds = File.ReadAllLines(file);
    
            var result = Tournament.GetScoreAgainstOpponent(rounds.ToList());
            Console.WriteLine("Part 1: Score = {0}", result);

            result = Tournament.GetScoreFromMatchTarget(rounds.ToList());
            Console.WriteLine("Part 2: Score = {0}", result);
        }
    }
}