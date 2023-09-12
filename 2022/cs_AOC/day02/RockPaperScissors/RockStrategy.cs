using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    public class RockStrategy : IMatchStrategy
    {
        public EOptions GetOptionForMatchScore(EScore targetResult)
        {
            return targetResult switch
            {
                EScore.Loss => EOptions.Scissors,
                EScore.Draw => EOptions.Rock,
                EScore.Win => EOptions.Paper,
                _ => throw new NotImplementedException()
            };
        }

        public EScore GetMatchScore(EOptions input)
        {
            return input switch
            {
                EOptions.Rock => EScore.Draw,
                EOptions.Paper => EScore.Loss,
                EOptions.Scissors => EScore.Win,
                _ => throw new NotImplementedException()
            };
        }
    }
}
