using System;
using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class LocationQueryTests
    {
        [Fact]
        public void For_GivenNoSpecializedSecretaries_ShouldThrowNullReferenceException()
        {
            var sut = new LocationQuery {Secretaries = new List<Secretary>()};

            Assert.Throws<NullReferenceException>(
                () => sut.For(new TestEntity() { Id = 1 })    
            );
        }
    }
}