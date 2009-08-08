using Xunit;

namespace Secretary.UnitTests
{
    public class SchoolTests
    {
        [Fact]
        public void TrainFor_GivenAValidPath_ShouldReturnASecretaryTrainedToManageThatFolder()
        {
            ISecretary secretary = new Secretary();
            var school = new School(@"C:\");

            school.Train(ref secretary);

            Assert.Equal(@"C:\", secretary.FolderManaging);
        }
    }
}
