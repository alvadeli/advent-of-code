using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    public class ScissorsStrategy : IMatchStrategy
    {
        public EOptions GetOptionForMatchScore(EScore targetResult)
        {
            return targetResult switch
            {
                EScore.Loss => EOptions.Paper,
                EScore.Draw => EOptions.Scissors,
                EScore.Win => EOptions.Rock,
                _ => throw new NotImplementedException()
            };
        }

        public EScore GetMatchScore(EOptions input)
        {
            return input switch
            {
                EOptions.Rock => EScore.Loss,
                EOptions.Paper => EScore.Win,
                EOptions.Scissors => EScore.Draw,
                _ => throw new NotImplementedException()
            };
        }
    }
}
