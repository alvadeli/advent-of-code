using day02.RockPaperScissors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace day02
{
    public class Tournament
    {
        public static int GetScoreFromMatchTarget(List<string> tournamentRounds) 
        {
            int result = 0;

            foreach (var round in tournamentRounds)
            {
                string[] values = round.Split(" ");
                var opponent = GetOptionFromString(values[0]);
                var targetMatchScore = GetExpectedResultFromString(values[1]);


                IMatchStrategy strategy = GetStrategy(opponent);
                EOptions targetOption = strategy.GetOptionForMatchScore(targetMatchScore);

                result += (int)targetOption + (int)targetMatchScore;
            }
            return result;
        }

        public static int GetScoreAgainstOpponent(List<string> tournamentRounds)
        {
            int result = 0;

            foreach (var round in tournamentRounds)
            {
                string[] values = round.Split(" ");
                var opponent = GetOptionFromString(values[0]);
                var optionForBattle = GetOptionFromString(values[1]);

                IMatchStrategy strategy = GetStrategy(optionForBattle);
                EScore matchScore = strategy.GetMatchScore(opponent);

                result += (int)optionForBattle + (int)matchScore;
            }
            return result;
        }

        public static EOptions GetOptionFromString(string input)
        {
            return input switch
            {
                "A" => EOptions.Rock,
                "X" => EOptions.Rock,
                "B" => EOptions.Paper,
                "Y" => EOptions.Paper,
                "C" => EOptions.Scissors,
                "Z" => EOptions.Scissors,
                _ => throw new NotImplementedException(),
            };
        }

        public static EScore GetExpectedResultFromString(string input)
        {
            return input switch
            {
                "X" => EScore.Loss,
                "Y" => EScore.Draw,
                "Z" => EScore.Win,
                _ => throw new NotImplementedException(),
            };
        }

        private static IMatchStrategy GetStrategy(EOptions opponent)
        {
            return opponent switch
            {
                EOptions.Rock => new RockStrategy(),
                EOptions.Paper => new PaperStrategy(),
                EOptions.Scissors => new ScissorsStrategy(),
                _ => throw new NotImplementedException()
            };
        }
    }
}
