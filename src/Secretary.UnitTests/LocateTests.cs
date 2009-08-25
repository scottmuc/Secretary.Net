using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class LocateTests
    {
        [Fact]
        public void IsInitialized_GivenACollectionOfSecretaries_ShouldReturnTrue()
        {
            Locate.InitializeWith(new List<Secretary>());

            var result = Locate.IsInitialized;

            Assert.True(result);
        }
    }
}
