using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    public class PaperStrategy : IRCPStrategy
    {
        public EOptions GetOptionForTargetResult(EResult targetResult)
        {
            return targetResult switch
            {
                EResult.Loss => EOptions.Rock,
                EResult.Draw => EOptions.Paper,
                EResult.Win => EOptions.Scissors,
                _ => throw new NotImplementedException()
            };
        }

        public EResult Result(EOptions input)
        {
            return input switch
            {
                EOptions.Rock => EResult.Win,
                EOptions.Paper => EResult.Draw,
                EOptions.Scissors => EResult.Loss,
                _ => throw new NotImplementedException()
            };
        }
    }
}
