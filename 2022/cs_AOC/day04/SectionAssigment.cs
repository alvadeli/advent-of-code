using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    class SectionAssignment
    {
        private SectionAssignment(int firstId, int secondId)
        {
            FirstId = firstId;
            SecondId = secondId;
        }

        public int FirstId { get; private set; }
        public int SecondId { get; private set; }

        public static SectionAssignment CreateFromListEntry(string rangeListEntry) 
        {
            string[] range = rangeListEntry.Split("-");
            return new SectionAssignment(int.Parse(range[0]), int.Parse(range[1]));
        }

        public bool IsValueInSectionRange(int value)
        {
            return value >= FirstId && value <= SecondId;
        }

        public bool IsSubset(SectionAssignment other)
        {
            return FirstId >= other.FirstId && SecondId <= other.SecondId;
        }

        public bool HasOverLap(SectionAssignment other)
        {
            bool firstIdInsideOther = other.IsValueInSectionRange(FirstId);
            bool secondIdInsideOther = other.IsValueInSectionRange(SecondId);

            return firstIdInsideOther || secondIdInsideOther;
        }

 

    }
}
