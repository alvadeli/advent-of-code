using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day05
{
    public class CrateRearrangementProcess
    {
        public enum CraneType
        {
            CrateMover9000,
            CrateMover9001
        }


        public static string GetTopCratesAtferRearrangement(string instructions, CraneType crateMoverType)
        {
            var inputSections = instructions.Split("\r\n\r\n");
            var crates = CreateCrates(inputSections[0]);
            var steps = GetSteps(inputSections[1]);
            
            RearrangeCrates(steps,crates, crateMoverType);
            return GetTopCrates(crates);

        }

        private static string GetTopCrates(List<List<char>> crates)
        {
            string topCrates = "";

            foreach (var stack in crates)
            {
                topCrates += stack.Last();
            }
            return topCrates;
        }

        private static void RearrangeCrates(List<CrateRearrangement> steps, List<List<char>> crates,CraneType crateMover)
        {
            switch (crateMover)
            {
                case CraneType.CrateMover9000:
                    foreach (var step in steps)
                    {
                        crates[step.FromStack - 1].MoveElementsReversedTo(crates[step.ToStack - 1], step.CratesToMove);
                    }
                    break;
                case CraneType.CrateMover9001:
                    foreach (var step in steps)
                    {
                        crates[step.FromStack - 1].MoveRangeTo(crates[step.ToStack - 1], step.CratesToMove);
                    }
                    break;
                default:
                    throw new NotImplementedException(crateMover.ToString());
            }
     
        }

        private static List<CrateRearrangement> GetSteps(string arrangementInfo)
        {
            string[] stepInstructions = arrangementInfo.Split("\r\n");

            var rearrangements = new List<CrateRearrangement>();
            foreach (string stepInstruction in stepInstructions)
            {
                string[] parts = stepInstruction.Split(" ");

                var rearrangement = new CrateRearrangement()
                {
                    CratesToMove = int.Parse(parts[1]),
                    FromStack = int.Parse(parts[3]),
                    ToStack = int.Parse(parts[5])
                };

                rearrangements.Add(rearrangement);
            }
            return rearrangements;
        }

        private static List<List<char>> CreateCrates(string crateInfo)
        {
            var crates = new List<List<char>>();
            var list = crateInfo.Split("\r\n").Reverse().ToList();

            list.RemoveAt(0);

            var cratePositions = new List<int>();

            for (int i = 0; i < list[0].Length; i++)
            {
                if (char.IsLetter(list[0][i]))
                {
                    cratePositions.Add(i);
                }
            }

            for (int i = 0; i < cratePositions.Count; i++)
            {
                crates.Add(new List<char>());
            }

            foreach (var row in list)
            {
                for (int i = 0; i < cratePositions.Count; i++)
                {
                    char current = row[cratePositions[i]];
                    if (char.IsLetter(current))
                    {
                        crates[i].Add(current);
                    }
                }
            }

            return crates;
        }
    }
}
