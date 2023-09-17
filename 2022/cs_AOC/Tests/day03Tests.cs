using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day03Tests
    {
        private readonly string[] _rucksacks;

        public day03Tests()
        {
            string testFile = TestData.Input.GetFile("day03-demo-input.txt");
            _rucksacks = File.ReadAllLines(testFile);
        }


        [Fact]
        public void RucksackPriority_GetPrioritiesSum_ReturnInt()
        {
            //Arrange

            //Act
            int actual = day03.RucksackPriority.GetPrioritiesSum(_rucksacks);

            //Assert
            actual.Should().Be(157);
        }

        [Fact]
        public void RucksackPriority_GetGroupPrioritiesSum_ReturnInt()
        {
            //Arrange

            //Act
            int actual = day03.RucksackPriority.GetGroupPrioritiesSum(_rucksacks);

            //Assert
            actual.Should().Be(70);
        }
    }
}
