namespace day04
{
    class AssignmentPair
    {
        private AssignmentPair(SectionAssignment firstAssignment, SectionAssignment secondAssignment)
        {
            FirstAssignment = firstAssignment;
            SecondAssignment = secondAssignment;
        }

        public static AssignmentPair CreateFromListEntry(string entry)
        {
            string[] sectionpair = entry.Split(',');
            var firstAssignment = SectionAssignment.CreateFromListEntry(sectionpair[0]);
            var secondAssignment = SectionAssignment.CreateFromListEntry(sectionpair[1]);
            return new AssignmentPair(firstAssignment, secondAssignment);
        }

        public SectionAssignment FirstAssignment { get; private set; }
        public SectionAssignment SecondAssignment { get; private set; }

        public bool AreSectionsSubset()
        {
            return FirstAssignment.IsSubset(SecondAssignment) || SecondAssignment.IsSubset(FirstAssignment);
        }

        public bool HasOverlapps()
        {
            return FirstAssignment.HasOverLap(SecondAssignment) || SecondAssignment.HasOverLap(FirstAssignment);
        }

    }
}
