using Secretary.Secretaries;
using Xunit;

namespace Secretary.UnitTests.Secretaries
{
    public class LocalFileSecretaryTests
    {
        const string tempPath = @"C:\temp";

        [Fact]
        public void FolderManaging_ConstructedWithAPath_ShouldReturnPathInstantiatedWith()
        {
            var secretary = new LocalFileSecretary(tempPath);

            Assert.Equal(tempPath, secretary.FolderManaging);
        }

        [Fact]
        public void GetFile_GivenAFileName_ShouldReturnAFile()
        {
            var secretary = new LocalFileSecretary(tempPath);

            var result = secretary.GetFile("test.txt").AbsoluteFilePath;

            Assert.Equal(@"C:\temp\test.txt", result);
        }
    }
}