using Xunit;

namespace Secretary.UnitTests
{
    public class SpecializationKeyTests
    {
        [Fact]
        public void Equals_GivenKeyWithDifferentFileType_ShouldReturnFalse()
        {
            var key = new SpecializationKey(typeof (TestEntity), FileType.Default);
            var other = new SpecializationKey(typeof(TestEntity), FileType.Image);

            var result = key.Equals(other);

            Assert.False(result);
        }

        [Fact]
        public void Equals_GivenNullObject_ShouldReturnFalse()
        {
            var key = new SpecializationKey(typeof(TestEntity), FileType.Default);

            var result = key.Equals(null as object);

            Assert.False(result);
        }

        [Fact]
        public void GetHashCode_IsComputedFromTypeAndFileType()
        {
            var key = new SpecializationKey(typeof(TestEntity), FileType.Default);
            var expectedHashCode = typeof(TestEntity).GetHashCode() ^ FileType.Default.GetHashCode();

            var hashcode = key.GetHashCode();

            Assert.Equal(expectedHashCode, hashcode);
        }
    }
}
