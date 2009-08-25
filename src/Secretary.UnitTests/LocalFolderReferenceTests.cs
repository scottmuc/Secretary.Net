using Xunit;

namespace Secretary.UnitTests
{
    public class LocalFolderReferenceTests
    {
        [Fact]
        public void AbsolutePath_UponConstruction_ShouldReturnFullPathToFolder()
        {
            var folder = new LocalFolderReference(@"C:\temp");

            var result = folder.AbsolutePath;

            Assert.Equal(@"C:\temp", result);
        }
    }
}