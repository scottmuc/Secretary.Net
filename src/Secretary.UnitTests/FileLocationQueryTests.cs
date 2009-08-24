using System;
using System.Collections.Generic;
using Xunit;

namespace Secretary.UnitTests
{
    public class FileLocationQueryTests
    {
        [Fact]
        public void For_GivenNoSpecializedSecretaries_ShouldThrowNullReferenceException()
        {
            var sut = new FileLocationQuery(FileType.File) {Secretaries = new List<Secretary>()};

            Assert.Throws<NullReferenceException>(
                () => sut.For(new TestEntity() { Id = 1 })    
            );
        }
    }
}
