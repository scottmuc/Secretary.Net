using System;
using System.Collections.Generic;
using System.IO;

namespace Secretary
{
    public static class FileExtensions
    {
        public static IDictionary<Type, object> pathBuildingStrategies =
            new Dictionary<Type, object>();

        public static IFile For<ENTITY>(this IFile initialFile, ENTITY entity)
        {
            var pathFactory = pathBuildingStrategies[typeof (ENTITY)];

            var entityPath = ((Func<ENTITY, string>) pathFactory).Invoke(entity);

            var newFolder = Path.Combine(initialFile.FolderName, entityPath);
            var newAbsolutePath = Path.Combine(newFolder, initialFile.FileName);

            return new File(newAbsolutePath);
        }
    }
}