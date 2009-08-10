using Secretary.Schools;
using Xunit;

namespace Secretary.UnitTests.Schools
{
    public class LocalFileSecretarySchoolTests
    {
        [Fact]
        public void GetTrainedSecretary_UsingASchool_ShouldReturnASecretaryTrainedToManageThatFolder()
        {            
            var school = new LocalFileSecretarySchool(@"C:\");

            var secretary = school.GetTrainedSecretary();

            Assert.Equal(@"C:\", secretary.FolderManaging);
        }
    }
}