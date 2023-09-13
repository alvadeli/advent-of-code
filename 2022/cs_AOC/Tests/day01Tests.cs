using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day01Tests
    {
        [Fact]
        public void ElveCalories_GetMaxCalories_ReturnInt()
        {
            //Arrange
            string file = Utils.TestData.GetFile("day01-demo-input.txt");
            string[] lines = File.ReadAllLines(file);

            //Act
            int actual = day01.EvleCalories.GetMaxCalories(lines);
            
            //Assert
            actual.Should().Be(24000);

        }
    }
}