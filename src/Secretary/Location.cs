using System;
using System.IO;

namespace Secretary
{
    public class Location
    {
        public static readonly Location Web = new Location("Web", 
            (basePath, fileName) =>
        {
            var fullPath = basePath + "/" + fileName;
            return new HttpFileReference(fullPath);
        }, 
            basePath => new HttpFolderReference(basePath) 
        );

        public static readonly Location Local = new Location("Local", 
            (basePath, fileName) =>
        {
            var fullPath = Path.Combine(basePath, fileName);
            return new LocalFileReference(fullPath);
        }, 
            basePath => new LocalFolderReference(basePath)
        );


        public Location(string name, Func<string, string, IFile> fileFactoryMethod, Func<string, IFolder> folderFactoryMethod)
        {
            Name = name;
            CreateFileInstance = fileFactoryMethod;
            CreateFolderInstance = folderFactoryMethod;
        }

        public Func<string, string, IFile> CreateFileInstance;
        public Func<string, IFolder> CreateFolderInstance;

        public string Name { get; private set; }

        public override string ToString()
        {
            return "Location." + Name;
        }
    }
}
