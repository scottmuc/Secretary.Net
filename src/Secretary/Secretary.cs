using System;
using System.IO;

namespace Secretary
{
    /// <summary>
    /// I purposely put very little logic in the Secretary class. This class is
    /// responsible for holding instructions from it's training and acting upon
    /// those instructions when asked.
    /// </summary>
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

        public virtual IFolder GetFolder()
        {
            return new LocalFolderReference(RootFolder);
        }
    }

    public class Secretary<TEntity> : Secretary
    {
        public TEntity Entity { get; set; }
        public Func<TEntity, string> EntityPathBuilder { get; set; }

        public override IFile Locate(string fileName)
        {
            var fullPathToFile = Path.Combine(GetBasePath(), fileName);

            return FileTypeHandled.CreateInstance(fullPathToFile);
        }

        public override IFolder GetFolder()
        {
            return new LocalFolderReference(GetBasePath());
        }

        protected string GetBasePath()
        {
            var entityPath = EntityPathBuilder.Invoke(Entity);
            var basePath = Path.Combine(RootFolder, entityPath);

            return basePath;
        }
    }
}
