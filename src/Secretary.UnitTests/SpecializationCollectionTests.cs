using Xunit;

namespace Secretary.UnitTests
{
    public class SpecializationCollectionTests
    {
        [Fact]
        public void Get_WhereKeyDoesNotExist_ShouldThrowSpecializationNotFoundException()
        {
            var sut = new SpecializationCollection();

            Assert.Throws<SpecializationNotFoundException>(
                () => sut.Get<TestEntity>(FileType.File)
            );
        }
    }
}