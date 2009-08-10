using System;
using System.IO;

namespace Secretary.UnitTests
{
    public class SpecializedSecretary<TEntity> : Secretary
    {
        public Type Specialization { get; set; }
        public Func<TEntity, string> pathDelegate;

        public string GetFile(string fileName, TEntity entity)
        {
            var fullPath = Path.Combine(base.RootFolder, pathDelegate.Invoke(entity));
            var fullFilePath = Path.Combine(fullPath, fileName);

            return fullFilePath;
        }
    }
}