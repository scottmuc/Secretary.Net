using Xunit;

namespace Secretary.UnitTests
{
    public class FileTypeTests
    {
        [Fact]
        public void Name_ConstructedWithAName_ShouldReturnNameConstructedWith()
        {
            var sut = new FileType("TestName");

            Assert.Equal("TestName", sut.Name);
        }
    }
}