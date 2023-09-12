using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace day03
{
    internal static class RucksackPriority
    {
        private const char CharWhiteSpace = ' ';

        public static int GetPrioritiesSum(string[] rucksacks)
        {
            int sum = 0;
            foreach (string rucksack in rucksacks)
            {
                char commonItem = GetCommonRucksackItem(rucksack);
                sum += GetPriorityValue(commonItem);
            }
            return sum;
        }

        public static int GetGroupPrioritiesSum(string[] rucksacks) 
        {
            const int groupSize = 3;
            int sum= 0;

            for (int i = 0; i < rucksacks.Count(); i+=groupSize) 
            {
                string[] group = new string[groupSize] { rucksacks[i], rucksacks[i+1], rucksacks[i+2] };
                char commonItem = GetCommonGroupItem(group);
                sum += GetPriorityValue(commonItem);
            }
            return sum;

        }

        private static char GetCommonRucksackItem(string rucksack)
        {
            int middleIndex = rucksack.Length / 2;

            string firstCompartment = rucksack[..middleIndex];
            string secondCompartment = rucksack[middleIndex..];

            foreach (var item in firstCompartment)
            {
                if (secondCompartment.Contains(item))
                {
                    return item;
                }
            }

            return CharWhiteSpace;
        }

        private static char GetCommonGroupItem(string[] rucksackGroup)
        {
            foreach (var item in rucksackGroup[0])
            {
                if (rucksackGroup[1].Contains(item) && rucksackGroup[2].Contains(item))
                {
                    return item;
                }
            }
            return CharWhiteSpace;
        }

        static int GetPriorityValue(char item)
        {
            if (char.IsWhiteSpace(item))
            {
                return 0;
            }

            if (char.IsLower(item))
            {
                // Lowercase item types a through z have priorities 1 through 26.
                // Ascii Offset: e.g for a -> 97 - 96 = 1
                int lowercaseAsiiOffset = -96;
                return item + lowercaseAsiiOffset;
            }

            // Uppercase item types A through Z have priorities 27 through 52.
            // Ascii Offset: e.g for A -> 65 - 38 = 27
            int UpperCaseAsciiOffset = -38;
            return item + UpperCaseAsciiOffset;
        }
    }
}
