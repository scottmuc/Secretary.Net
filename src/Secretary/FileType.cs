using System;
using Secretary.FileReferences;

namespace Secretary
{
    public class FileType
    {
        public static FileType File = new FileType();

        public Func<string, IFile> CreateInstance = (path) => new LocalFileReference(path);
    }
}