using Xunit;

namespace Secretary.UnitTests
{
    public class SecretaryTests
    {
        const string tempPath = @"C:\temp";

        [Fact]
        public void FolderManaging_ConstructedWithAPath_ShouldReturnPathInstantiatedWith()
        {
            var secretary = new Secretary(tempPath);

            Assert.Equal(tempPath, secretary.FolderManaging);
        }

        [Fact]
        public void GetFile_GivenAFileName_ShouldReturnAFile()
        {
            var secretary = new Secretary(tempPath);

            var result = secretary.GetFile("test.txt").AbsoluteFilePath;

            Assert.Equal(@"C:\temp\test.txt", result);
        }
    }
}
