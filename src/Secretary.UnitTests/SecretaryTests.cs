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
                FileTypeHandled = FileType.File,
                LocationContext = Location.Local
            };

            var fileRef = sut.Locate("test.txt");
            var resultingPath = fileRef.AbsoluteFilePath;

            Assert.Equal(@"C:\test\test.txt", resultingPath);
        }

        [Fact]
        public void GetFolder_GivenRequirements_ShouldProvideBasedRootPath()
        {
            var sut = new Secretary
            {
                RootFolder = @"C:\test",
                FileTypeHandled = FileType.File,
                LocationContext = Location.Local
            };

            var folderRef = sut.GetFolder();
            var resultingPath = folderRef.AbsolutePath;

            Assert.Equal(@"C:\test", resultingPath);            
        }

        [Fact]
        public void Locate_WhenSpecializedForTestEntity_UsesOveriddenLocateMethod()
        {
            Secretary sut = new Secretary<TestEntity>
            {
                RootFolder = @"C:\test",
                FileTypeHandled = FileType.File,
                LocationContext = Location.Local,
                EntityPathBuilder = e => @"entities\" + e.Id.ToString(),
                Entity = new TestEntity {Id = 1}
            };

            var fileRef = sut.Locate("test.txt");
            var resultingPath = fileRef.AbsoluteFilePath;

            Assert.Equal(@"C:\test\entities\1\test.txt", resultingPath);           
        }

        [Fact]
        public void GetFolder_WhenSpecializedForTestEntity_UsesOverridenGetFolderMethod()
        {
            Secretary sut = new Secretary<TestEntity>
            {
                RootFolder = @"C:\test",
                FileTypeHandled = FileType.File,
                LocationContext = Location.Local,
                EntityPathBuilder = e => @"entities\" + e.Id.ToString(),
                Entity = new TestEntity { Id = 1 }
            };

            var folderRef = sut.GetFolder();
            var resultingPath = folderRef.AbsolutePath;

            Assert.Equal(@"C:\test\entities\1", resultingPath);
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
