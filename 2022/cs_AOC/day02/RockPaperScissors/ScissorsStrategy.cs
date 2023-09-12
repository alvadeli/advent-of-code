using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    public class ScissorsStrategy : IRCPStrategy
    {
        public EOptions GetOptionForTargetResult(EResult targetResult)
        {
            return targetResult switch
            {
                EResult.Loss => EOptions.Paper,
                EResult.Draw => EOptions.Scissors,
                EResult.Win => EOptions.Rock,
                _ => throw new NotImplementedException()
            };
        }

        public EResult Result(EOptions input)
        {
            return input switch
            {
                EOptions.Rock => EResult.Loss,
                EOptions.Paper => EResult.Win,
                EOptions.Scissors => EResult.Draw,
                _ => throw new NotImplementedException()
            };
        }
    }
}
