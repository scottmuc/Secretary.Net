using System;
using Xunit;

namespace Secretary.UnitTests
{
    public class SecretaryTests
    {
        [Fact]
        public void Constructor_DefaultExists()
        {
            var sut = new Secretary();
            Assert.NotNull(sut);
        }

        [Fact]
        public void Locate_GivenRequirements_ShouldProvideAnAccurateFileReference()
        {
            var sut = new Secretary
            {
                RootFolder = @"C:\test",
                FileTypeHandled = FileType.File
            };

            var fileRef = sut.Locate("test.txt");
            var resultingPath = fileRef.AbsoluteFilePath;

            Assert.Equal(@"C:\test\test.txt", resultingPath);
        }

        [Fact]
        public void Locate_WhenSpecializedForTestEntity_UsesOveriddenLocateMethod()
        {
            Secretary sut = new Secretary<TestEntity>
            {
                RootFolder = @"C:\test",
                FileTypeHandled = FileType.File,
                EntityPathBuilder = e => @"entities\" + e.Id.ToString(),
                Entity = new TestEntity {Id = 1} 
            };

            var fileRef = sut.Locate("test.txt");
            var resultingPath = fileRef.AbsoluteFilePath;

            Assert.Equal(@"C:\test\entities\1\test.txt", resultingPath);           
        }

        [Fact]
        public void Locate_WhenFileTypeHandledIsNull_ShouldThrowNullReferenceException()
        {
            var sut = new Secretary
            {
                RootFolder = @"C:\test",
            };

            Assert.Throws<NullReferenceException>(() => sut.Locate("test.txt"));
        }
    }
}
