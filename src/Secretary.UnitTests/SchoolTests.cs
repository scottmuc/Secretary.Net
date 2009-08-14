using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        private const string testSchoolName = "TestSchool";
        private const string testSchoolPath = @"C:\temp\TestSchool";
        private readonly IList<Enrollment> enrollments = new List<Enrollment>();
        private readonly SpecializationCollection specializations = new SpecializationCollection();

        private School GetTestSchool()
        {
            return new School(testSchoolName, testSchoolPath, enrollments, specializations);
        }

        [Fact]
        public void FolderAndName_GivenInConstructor_ShouldBeSame()
        {
            var sut = GetTestSchool();

            Assert.Equal(testSchoolPath, sut.Folder);
            Assert.Equal(testSchoolName, sut.Name);
        }

        [Fact]
        public void WhenStudentEnollsInSchool_StaysInEnrollmentsCollection()
        {
            var student = new Secretary();

            var sut = GetTestSchool();

            sut.Enroll(student);
            var studentIsEnrolled = enrollments.Any(e => e.Secretary == student);

            Assert.True(studentIsEnrolled);
        }

        [Fact]
        public void Enrollments_GivenCollection_ShouldReturnInternalCollection()
        {
            var sut = GetTestSchool();

            Assert.Equal(enrollments, sut.Enrollments);
        }
    }
}
