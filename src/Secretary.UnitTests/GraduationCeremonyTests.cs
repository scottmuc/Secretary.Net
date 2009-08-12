using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class GraduationCeremonyTests
    {
        private Secretary GetGraduate(Enrollment enrollment)
        {
            var enrollments = new List<Enrollment> { enrollment };

            var ceremony = new GraduationCeremony(enrollments);
            var grads = ceremony.GetGraduates();

            return grads[0];
        }


        [Fact]
        public void Graduates_GivenEnrollments_ShouldKnowWhatToDo()
        {
            var enrollment = new Enrollment
            {
                FileType = FileType.File,
                School = new School("TestSchool", @"C:\temp"),                
                Secretary = new Secretary()
            };

            var grad = GetGraduate(enrollment);

            Assert.Equal("TestSchool", grad.AlmaMater);

        }
    }
}
