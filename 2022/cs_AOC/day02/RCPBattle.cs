using day02.RockPaperScissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02
{
    public static class RCPBattle
    {
        private static IRCPStrategy GetStrategy(EOptions opponent)
        {
            return opponent switch
            {
                EOptions.Rock => new RockStrategy(),
                EOptions.Paper => new PaperStrategy(),
                EOptions.Scissors => new ScissorsStrategy(),
                _ => throw new NotImplementedException()
            };
        }

        

        public static int GetPointsFromBattle(EOptions input, EOptions opponent)
        {
            IRCPStrategy strategy = GetStrategy(input);

            EResult result = strategy.Result(opponent);

            return (int)input + (int)result;  

        }

        public static int GetPointsWithTargetResult(EOptions opponent, EResult targetAgainstOpponent) 
        {
            IRCPStrategy strategy = GetStrategy(opponent);

            EOptions targetOption = strategy.GetOptionForTargetResult(targetAgainstOpponent);

            return (int)targetOption + (int)targetAgainstOpponent;

        }
    }
}
