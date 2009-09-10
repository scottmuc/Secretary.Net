using System;
using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class LocateTests : IDisposable
    {
        [Fact]
        public void IsInitialized_GivenACollectionOfSecretaries_ShouldReturnTrue()
        {
            Locate.InitializeWith(new List<Secretary>());

            var result = Locate.IsInitialized;

            Assert.True(result);
        }

        [Fact]
        public void Usage_WhenUninitialized_ShouldThrowException()
        {
            Assert.Throws<LocatorUnitializedException>(() => Locate.FolderForType(FileType.Image));            
        }


        public void Dispose()
        {
            Locate.Reset();
        }
    }
}
