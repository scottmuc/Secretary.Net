using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class FileLocatorTests
    {
        [Fact]
        public void Secretaries_GivenACollectionOfSecretaries_ShouldReturnPassedInReference()
        {
            var secretaries = new List<Secretary>();

            FileLocator.InitializeWith(secretaries);

            Assert.Same(secretaries, FileLocator.Secretaries);
        }
    }
}
