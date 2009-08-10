using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        [Fact]
        public void Should_be_created_with_a_name_and_folder_root()
        {
            var sut = new School("SchoolOfArtists", @"C:\temp\artists");
        }
    }
}