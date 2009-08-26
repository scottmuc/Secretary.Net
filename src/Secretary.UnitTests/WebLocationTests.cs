using Xunit;

namespace Secretary.UnitTests
{
    public class WebLocationTests
    {
        [Fact]
        public void Combine_WithBackSlashesInPath_ShouldReplaceThemWithForwardSlashes()
        {
            var sut = new HttpLocation();

            var result = sut.Combine("http://localhost/test", @"again\1");

            Assert.Equal("http://localhost/test/again/1", result);
        }
    }
}