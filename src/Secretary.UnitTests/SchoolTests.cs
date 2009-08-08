using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        [Fact]
        public void GetTrainedSecretary_UsingASchool_ShouldReturnASecretaryTrainedToManageThatFolder()
        {            
            var school = new School(@"C:\");

            var secretary = school.GetTrainedSecretary();

            Assert.Equal(@"C:\", secretary.FolderManaging);
        }
    }
}
