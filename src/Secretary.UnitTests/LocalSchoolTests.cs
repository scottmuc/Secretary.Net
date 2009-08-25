using System.Linq;
using Xunit;

namespace Secretary.UnitTests
{
    public class LocalSchoolTests
    {
        private const string testSchoolName = "TestSchool";
        private const string testSchoolPath = @"C:\temp\TestSchool";

        private School GetTestSchool()
        {
            return new LocalSchool(testSchoolName, testSchoolPath);
        }

        [Fact]
        public void FolderAndName_GivenInConstructor_ShouldBeSame()
        {
            var sut = GetTestSchool();

            Assert.Equal(testSchoolName, sut.Name);
        }

        [Fact]
        public void WhenStudentEnollsInSchool_StaysInEnrollmentsCollection()
        {
            var sut = GetTestSchool();

            sut.Enroll();
            var studentIsEnrolled = sut.Enrollments.Any();

            Assert.True(studentIsEnrolled);
        }
    }
}
