using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class GraduationCeremonyTests
    {

        [Fact]
        public void Graduates_GivenEnrollments_ShouldKnowWhatToDo()
        {
            var enrollments = new List<Enrollment>
            {
                new Enrollment { FileType = FileType.File, Secretary = new Secretary() }
            };


            var ceremony = new GraduationCeremony(enrollments);
            var grads = ceremony.GetGraduates();

            Assert.Equal(1, grads.Count);

        }
    }
}