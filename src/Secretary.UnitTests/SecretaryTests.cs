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
    }
}