using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class LocateTests
    {
        [Fact]
        public void Secretaries_GivenACollectionOfSecretaries_ShouldReturnPassedInReference()
        {
            var secretaries = new List<Secretary>();

            Locate.InitializeWith(secretaries);

            Assert.Same(secretaries, Locate.Secretaries);
        }
    }
}
