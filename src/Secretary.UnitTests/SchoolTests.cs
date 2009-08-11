using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        private const string testSchoolName = "TestSchool";
        private const string testSchoolPath = @"C:\temp\TestSchool";

        private School GetTestSchool()
        {
            return new School(testSchoolName, testSchoolPath);
        }

    }
}