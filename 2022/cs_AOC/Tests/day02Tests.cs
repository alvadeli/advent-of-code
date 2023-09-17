using FluentAssertions;
using Xunit;

namespace Tests
{
    public class day02Tests
    {
        private readonly string[] _rounds;

        public day02Tests() 
        {
            string testFile = TestData.Input.GetFile("day02-demo-input.txt");
            _rounds = File.ReadAllLines(testFile);
        }


        [Fact]
        public void Tournament_GetScoreAgainstOpponent_ReturnInt()
        {
            //Arrange 

            //Act
            int actual = day02.Tournament.GetScoreAgainstOpponent(_rounds.ToList());

            //Assert
            actual.Should().Be(15);
        }


        [Fact]
        public void Tournament_GetScoreFromMatchTarget_ReturnInt()
        {
            //Arrange 

            //Act
            int actual = day02.Tournament.GetScoreFromMatchTarget(_rounds.ToList());

            //Assert
            actual.Should().Be(12);
        }
    }
}
