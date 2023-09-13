using System.Runtime.ExceptionServices;

namespace day04
{
    public class Program
    {
        private static bool demo = false;

        static void Main(string[] args)
        {
            string file = Utils.Input.GetInputFile(demo);
            string[] assignmentList = File.ReadAllLines(file);
     
            int count = GetSubsets(assignmentList);
            Console.WriteLine("Part 1: Subsets of Assignment Pairs: {0}", count);

            count = GetOverlaps(assignmentList);
            Console.WriteLine("Part 2: Overlapping Assignment Pairs: {0}", count);



        }

        public static int GetSubsets(string[] assignmentList)
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

        public static int GetOverlaps(string[] assignmentList)
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