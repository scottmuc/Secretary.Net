using System;
using System.Collections.Generic;
using System.IO;
using Secretary.FileReferences;

namespace Secretary
{
    public static class FileExtensions
    {
        public static IDictionary<Type, object> pathBuildingStrategies =
            new Dictionary<Type, object>();

        public static IFile For<TEntity>(this IFile initialFile, TEntity entity)
        {
            var pathFactory = pathBuildingStrategies[typeof (TEntity)];

            var entityPath = ((Func<TEntity, string>) pathFactory).Invoke(entity);

            var newFolder = Path.Combine(initialFile.FolderName, entityPath);
            var newAbsolutePath = Path.Combine(newFolder, initialFile.FileName);

            return new LocalFileReference(newAbsolutePath);
        }
    }
}
