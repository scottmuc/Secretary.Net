using Secretary.Schools;
using Secretary.Secretaries;
using Xunit;

namespace Secretary.UnitTests.Schools
{
    public class TempAgencyTests
    {
        [Fact]
        public void GetTrainedSecretary_ShouldReturnASecretaryThatIsATemp()
        {
            var school = new TempAgency();

            var secretary = school.GetTrainedSecretary();

            var result = secretary as Temp;

            Assert.NotNull(result);
        }
    }
}
