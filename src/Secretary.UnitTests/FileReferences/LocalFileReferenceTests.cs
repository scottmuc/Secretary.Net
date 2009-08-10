using System;
using Secretary.FileReferences;
using Xunit;

namespace Secretary.UnitTests.FileReferences
{
    public class LocalFileReferenceTests
    {
        [Fact]
        public void AbsoluteFilePath_UponConstructionOfAPath_ShouldReturnThatPath()
        {
            var file = new LocalFileReference(@"C:\test\test.txt");

            var result = file.AbsoluteFilePath;

            Assert.Equal(@"C:\test\test.txt", result);
        }

        [Fact]
        public void BasePath_UponConstructionOfAPath_ShouldReturnTheFolder()
        {
            var file = new LocalFileReference(@"C:\test\test.txt");

            var result = file.FolderName;

            Assert.Equal(@"C:\test", result);
        }

        [Fact]
        public void FileName_UponConstructionOfAPath_ShouldReturnThatPath()
        {
            var file = new LocalFileReference(@"C:\test\test.txt");

            var result = file.FileName;

            Assert.Equal(@"test.txt", result);
        }

        [Fact]
        public void AbsoluteFilePath_ForAnEntity_ShouldReturnThatPathWithEntityStrategyInTheMiddle()
        {
            FileExtensions.pathBuildingStrategies.Add(typeof (TestEntity), new Func<TestEntity, string>(e => e.Id.ToString()));

            var testEntity = new TestEntity {Id = 1};
            var result = new LocalFileReference(@"C:\test\test.txt").For(testEntity).AbsoluteFilePath;

            Assert.Equal(@"C:\test\1\test.txt", result);
        }
    }

    public class TestEntity
    {
        public int Id { get; set; }
    }
}