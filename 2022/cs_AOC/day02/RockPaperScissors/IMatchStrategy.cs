using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    internal interface IMatchStrategy
    {
        EOptions GetOptionForMatchScore(EScore targetResult);
        EScore GetMatchScore(EOptions opponent);      
    }
}
