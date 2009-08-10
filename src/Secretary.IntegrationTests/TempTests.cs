using System.IO;
using Secretary.Secretaries;
using Xunit;

namespace Secretary.IntegrationTests
{
    public class TempTests
    {
        [Fact]
        public void ManagingFolder_ForATemp_ShouldBeTheCurrentTempPath()
        {
            var tempPath = Path.GetTempPath();

            var tempSecretary = new Temp();

            Assert.Equal(tempPath, tempSecretary.FolderManaging);
        }
    }
}