using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        private const string testSchoolName = "TestSchool";
        private const string testSchoolPath = @"C:\temp\TestSchool";

        private ISchool GetTestSchool()
        {
            return new School(testSchoolName, testSchoolPath);
        }


        [Fact]
        public void Should_be_created_with_a_name_and_folder_root()
        {
            var sut = GetTestSchool();
        }
    }
}