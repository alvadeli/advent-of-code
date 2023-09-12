using System.Runtime.ExceptionServices;

namespace day04
{
    internal class Program
    {
        private static bool demo = false;
        private static bool firstPart = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);

            string[] assignmentList = File.ReadAllLines(file);

            int count = 0;
            if (firstPart)
            {
                count = GetSubsets(assignmentList);
            }
            else 
            {
                count = GetOverlaps(assignmentList);
            }

            Console.WriteLine("Overlapping Assignment Pairs: {0}", count);

        }

        private static int GetSubsets(string[] assignmentList)
        {
            int subsetAssignments = 0;

            foreach (string assignment in assignmentList)
            {
                var assignmentPair = AssignmentPair.CreateFromListEntry(assignment);

                if (assignmentPair.AreSectionsSubset())
                {
                    subsetAssignments++;
                }                
            }

            return subsetAssignments;
        }

        private static int GetOverlaps(string[] assignmentList)
        {
            int overlappingAssignments = 0;

            foreach (string assignment in assignmentList)
            {
                var assignmentPair = AssignmentPair.CreateFromListEntry(assignment);

                if (assignmentPair.HasOverlapps())
                {
                    overlappingAssignments++;
                }
            }

            return overlappingAssignments;
        }






    }
}