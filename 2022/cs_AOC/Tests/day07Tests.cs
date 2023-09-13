using FluentAssertions;
using Xunit;
using day07;
using Directory = day07.Directory;


namespace Tests
{
    public class day07Tests
    {
        private readonly Directory _topLevelDirectory;

        public day07Tests()
        {
            string testFile = Utils.TestData.GetFile("day07-demo-input.txt");
            string[] terminalOutput = System.IO.File.ReadAllLines(testFile);
            _topLevelDirectory = FileSystem.ReconstructDirectory(terminalOutput);
        }


        [Fact]
        public void FileSystem_GetDirSizeSum_ReturnInt()
        {
            //Arrange
 
            //Act
            int actual = day07.FileSystem.GetDirSizeSum(_topLevelDirectory);

            //Assert
            actual.Should().Be(95437);
        }

        [Fact]
        public void FileSystem_GetDirectoryToFreeDisk_ReturnInt()
        {
            //Arrange

            //Act
            int actual = day07.FileSystem.GetDirectorySizeToFreeDisk(_topLevelDirectory);

            //Assert
            actual.Should().Be(24933642);
        }
    }
}
