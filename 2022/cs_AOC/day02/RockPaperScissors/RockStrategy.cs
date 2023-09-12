using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    public class RockStrategy : IRCPStrategy
    {
        public EOptions GetOptionForTargetResult(EResult targetResult)
        {
            return targetResult switch
            {
                EResult.Loss => EOptions.Scissors,
                EResult.Draw => EOptions.Rock,
                EResult.Win => EOptions.Paper,
                _ => throw new NotImplementedException()
            };
        }

        public EResult Result(EOptions input)
        {
            return input switch
            {
                EOptions.Rock => EResult.Draw,
                EOptions.Paper => EResult.Loss,
                EOptions.Scissors => EResult.Win,
                _ => throw new NotImplementedException()
            };
        }
    }
}
