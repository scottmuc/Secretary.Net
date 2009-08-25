using System;
using System.IO;

namespace Secretary
{
    /// <summary>
    /// This is a specialized secretary that handles a specific domain entity
    /// </summary>
    /// <typeparam name="TEntity">Type that the secretary specializes in handling</typeparam>
    public class Secretary<TEntity> : Secretary
    {
        public TEntity Entity { get; set; }
        public Func<TEntity, string> EntityPathBuilder { get; set; }

        public override IFile Locate(string fileName)
        {
            return LocationContext.CreateFileInstance(GetBasePath(), fileName);
        }

        public override IFolder GetFolder()
        {
            return LocationContext.CreateFolderInstance(GetBasePath());
        }

        protected string GetBasePath()
        {
            var entityPath = EntityPathBuilder.Invoke(Entity);

            // TODO move this to LocationContext delegate
            var basePath = Path.Combine(RootFolder, entityPath);

            return basePath;
        }
    }
}
