using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        [Fact]
        public void Specializations_WhenPassedInConstructor_ShouldBeTheSame()
        {
            var specializations = new SpecializationCollection();

            var sut = new TestSchool("testSchool", specializations);

            Assert.Same(specializations, sut.Specializations);
        }
    }

    internal class TestSchool : School
    {
        public TestSchool(string name) : base(name)
        {
        }

        public TestSchool(string name, SpecializationCollection specializations) 
            : base(name, specializations)
        {
        }

        public TestSchool(string name, SpecializationCollection specializations, IList<Enrollment> enrollments) 
            : base(name, specializations, enrollments)
        {
        }

        public override string BaseFilePath
        {
            get { return string.Empty; }
        }

        public override Location Location
        {
            get { return null; }
        }
    }
}