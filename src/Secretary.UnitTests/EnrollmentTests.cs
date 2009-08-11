using Rhino.Mocks;
using Xunit;

namespace Secretary.UnitTests
{
    public class EnrollmentTests
    {
        [Fact]
        public void SpecializingIn_WithImageType_UpdatesFileType()
        {
            var sut = new Enrollment();

            sut.SpecializingIn(FileType.Image);

            Assert.Equal(FileType.Image, sut.FileType);
        }

        [Fact]
        public void SettingEnrollmentFor_WithAnEntity_ShouldChangeToSepcializedSecretary()
        {
            var specializtionsStub = MockRepository.GenerateStub<SpecializationCollection>();
            specializtionsStub.Add<TestEntity>(FileType.File, null);
            var school = new School("Test", @"C:\Test", null, specializtionsStub);

            var sut = new Enrollment
            {
                Secretary = new Secretary(),
                FileType = FileType.File,
                School = school
            };

            sut.For<TestEntity>();

            var secretary = sut.Secretary as Secretary<TestEntity>;

            Assert.NotNull(secretary);
        }
    }
}
