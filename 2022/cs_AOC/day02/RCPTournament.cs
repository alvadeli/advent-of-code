using day02.RockPaperScissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02
{
    internal class RCPTournament
    {
        public static int GetTournamentRoundResult(string tournamentRound, bool firstPart)
        {
            string[] values = tournamentRound.Split(" ");
            var oppenent = GetOptionFromString(values[0]);
            
            if (firstPart)
            {    
                var optionForBattle = GetOptionFromString(values[1]);
                return RCPBattle.GetPointsFromBattle(optionForBattle, oppenent);
            }

            var resultForBattle = GetExpectedResultFromString(values[1]);

            return RCPBattle.GetPointsWithTargetResult(oppenent, resultForBattle);
        }


        public static int GetTournamentResult(List<string> tournamentRounds, bool firstStrategy)
        {
            int result = 0;

            foreach (var round in tournamentRounds)
            {
                result += GetTournamentRoundResult(round,firstStrategy);
            }
            return result;
        }

        public static EOptions GetOptionFromString(string input)
        {
            //A X Rock 
            //B Y Paper 
            //C Z Scissors 
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

        public static EResult GetExpectedResultFromString(string input)
        {
            //X loss
            //Y draw 
            //Z win 
            return input switch
            {
                "X" => EResult.Loss,
                "Y" => EResult.Draw,
                "Z" => EResult.Win,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
