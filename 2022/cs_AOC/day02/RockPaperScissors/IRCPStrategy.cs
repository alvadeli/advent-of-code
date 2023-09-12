using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day02.RockPaperScissors
{
    internal interface IRCPStrategy
    {
        EOptions GetOptionForTargetResult(EResult targetResult);
        EResult Result(EOptions opponent);      
    }
}
