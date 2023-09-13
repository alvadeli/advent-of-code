using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day01
{
    public static class EvleCalories
    {
        public static int GetMaxCalories(string[] lines)
        {
            int elveInventoryValue = 0;
            var elveInventoryValues = new List<int>() { };

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    elveInventoryValues.Add(elveInventoryValue);
                    elveInventoryValue = 0;
                    continue;
                }
                elveInventoryValue += int.Parse(line);

            }

            return elveInventoryValues.Max();
        }
    }
}
