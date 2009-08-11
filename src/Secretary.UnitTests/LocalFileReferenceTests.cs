using Xunit;

namespace Secretary.UnitTests
{
    public class LocalFileReferenceTests
    {
        [Fact]
        public void AbsoluteFilePath_UponConstructionOfAPath_ShouldReturnThatPath()
        {
            var file = new LocalFileReference(@"C:\test\test.txt");

            var result = file.AbsoluteFilePath;

            Assert.Equal(@"C:\test\test.txt", result);
        }

        [Fact]
        public void BasePath_UponConstructionOfAPath_ShouldReturnTheFolder()
        {
            var file = new LocalFileReference(@"C:\test\test.txt");

            var result = file.FolderName;

            Assert.Equal(@"C:\test", result);
        }

        [Fact]
        public void FileName_UponConstructionOfAPath_ShouldReturnThatPath()
        {
            var file = new LocalFileReference(@"C:\test\test.txt");

            var result = file.FileName;

            Assert.Equal(@"test.txt", result);
        }
    }
}