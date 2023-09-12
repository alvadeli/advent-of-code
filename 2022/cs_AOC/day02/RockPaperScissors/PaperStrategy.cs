using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    public class PaperStrategy : IMatchStrategy
    {
        public EOptions GetOptionForMatchScore(EScore targetResult)
        {
            return targetResult switch
            {
                EScore.Loss => EOptions.Rock,
                EScore.Draw => EOptions.Paper,
                EScore.Win => EOptions.Scissors,
                _ => throw new NotImplementedException()
            };
        }

        public EScore GetMatchScore(EOptions input)
        {
            return input switch
            {
                EOptions.Rock => EScore.Win,
                EOptions.Paper => EScore.Draw,
                EOptions.Scissors => EScore.Loss,
                _ => throw new NotImplementedException()
            };
        }
    }
}
