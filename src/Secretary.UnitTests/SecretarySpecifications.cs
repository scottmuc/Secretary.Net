using System;
using System.Linq;
using Xunit;

namespace Secretary.UnitTests
{
    public class SecretarySpecifications
    {
        [Fact]
        public void CanCreateASchoolSpecializingInTestEntity()
        {
            // Setup school with a specialization
            var school = new School("Test Entity U", @"C:\temp\TestEntities");

            school.Specializations.Add<TestEntity>(e => e.Id.ToString());

            // Enroll student in school for specialization
            var student = new Secretary();
            school.Enroll(student).SpecializingIn<TestEntity>();
            
            // Get a graduated Secretary
            var secretary = school.GraduateAllEnrolled().First();

            Assert.Equal("Test Entity U", secretary.AlmaMater);

            var specializedSecretary = secretary as SpecializedSecretary<TestEntity>;

            Assert.NotNull(specializedSecretary);
        }

    }
}