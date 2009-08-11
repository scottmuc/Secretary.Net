using System;
using System.IO;

namespace Secretary
{
    public class Secretary
    {
        public string AlmaMater { get; set; }
        public string RootFolder { get; set; }
        public FileType FileTypeHandled { get; set; }

        public virtual IFile Locate(string fileName)
        {
            var fullPathToFile = Path.Combine(RootFolder, fileName);

            return FileTypeHandled.CreateInstance(fullPathToFile);
        }
    }

    public class Secretary<TEntity> : Secretary
    {
        public TEntity Entity { get; set; }

        public Func<TEntity, string> EntityPathBuilder { get; set; }

        public override IFile Locate(string fileName)
        {
            var entityPath = EntityPathBuilder.Invoke(Entity);
            var basePath = Path.Combine(RootFolder, entityPath);
            var fullPathToFile = Path.Combine(basePath, fileName);

            return FileTypeHandled.CreateInstance(fullPathToFile);
        }
    }
}
