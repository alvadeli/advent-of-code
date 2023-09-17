using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day04Tests
    {
        private readonly string[] _assignmentList;

        public day04Tests()
        {
            string testFile = TestData.Input.GetFile("day04-demo-input.txt");
            _assignmentList = File.ReadAllLines(testFile);
        }


        [Fact]
        public void Program_GetSubsets_ReturnInt()
        {
            //Arrange

            //Act
            int actual = day04.Program.GetSubsets(_assignmentList);

            //Assert
            actual.Should().Be(2);
        }

        [Fact]
        public void Program_GetOverlapps_ReturnInt()
        {
            //Arrange

            //Act
            int actual = day04.Program.GetOverlaps(_assignmentList);

            //Assert
            actual.Should().Be(4);
        }
    }
}
