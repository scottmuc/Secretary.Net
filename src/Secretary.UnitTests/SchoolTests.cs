using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        private const string testSchoolName = "TestSchool";
        private const string testSchoolPath = @"C:\temp\TestSchool";
        private readonly IList<Enrollment> enrollments = new List<Enrollment>();
        private readonly SpecializationCollection specializations = new SpecializationCollection { DefaultFileType = FileType.File };

        private School GetTestSchool()
        {
            return new School(testSchoolName, testSchoolPath, enrollments, specializations);
        }

        [Fact]
        public void School_is_instantiated_with_name_and_root_Folder()
        {
            var sut = GetTestSchool();

            Assert.Equal(testSchoolPath, sut.Folder);
            Assert.Equal(testSchoolName, sut.Name);
        }

        [Fact]
        public void Enrollments_should_contain_enrolled_student()
        {
            var student = new Secretary();

            var sut = GetTestSchool();

            sut.Enroll(student);

            Assert.Equal(1, enrollments.Count);
        }

        [Fact]
        public void Specializations_should_contain_added_specialty()
        {
            var sut = GetTestSchool();

            sut.Specializations.Add<TestEntity>(e => e.Id.ToString());

            Assert.True(sut.Specializations.Contains<TestEntity>());
        }
    }
}
