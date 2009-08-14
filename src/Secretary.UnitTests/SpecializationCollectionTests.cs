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

        [Fact]
        public void Contains_WhenSpecializationIsAdded_ShouldBeTrue()
        {
            var sut = new SpecializationCollection();

            sut.Add<TestEntity>(null);

            Assert.True(sut.Contains<TestEntity>());
        }
    }
}