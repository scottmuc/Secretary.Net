using Rhino.Mocks;
using Xunit;

namespace Secretary.UnitTests
{
    public class SecretaryTests
    {
        [Fact]
        public void GetFile_WithNoContext_DelegatesRequestToTemp()
        {
            var mockTempAgency = MockRepository.GenerateMock<ISchool>();
            var stubbedSecetary = MockRepository.GenerateStub<ISecretary>();

            mockTempAgency.Expect(s => s.GetTrainedSecretary()).Return(stubbedSecetary);

            Secretary.TempAgency = mockTempAgency;
            Secretary.LocateFile("test.jpg");
        }
    }
}
