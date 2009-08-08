using Xunit;

namespace Secretary.UnitTests
{
    public class SecretarySchoolTests
    {
        [Fact]
        public void TrainFor_GivenAValidPath_ShouldReturnASecretaryTrainedToManageThatFolder()
        {
            var school = new SecretarySchool();

            var secretary = school.TrainFor(@"C:\");

            Assert.Equal(@"C:\", secretary.FolderManaging);
        }
    }
}
