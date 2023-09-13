using day05;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day05Tests
    {
        private readonly string _instructions;

        public day05Tests()
        {
            string file = Utils.TestData.GetFile("day05-demo-input.txt");
            _instructions = File.ReadAllText(file); ;
        }


        [Theory]
        [InlineData(CrateRearrangementProcess.CraneType.CrateMover9000, "CMZ")]
        [InlineData(CrateRearrangementProcess.CraneType.CrateMover9001, "MCD")]
        public void Crates_RearrangeWithCrateMover9000(CrateRearrangementProcess.CraneType crateMover, string expected)
        {
            //Arrange

            //Act
            string actual = day05.CrateRearrangementProcess.GetTopCratesAtferRearrangement(_instructions, crateMover);

            //Assert
            actual.Should().Be(expected);
        }


    }
}
