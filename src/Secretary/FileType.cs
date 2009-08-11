using System;

namespace Secretary
{
    public class FileType
    {
        public static FileType File = new FileType();
        public static FileType Image = new FileType();
        public static FileType Audio = new FileType();

        public FileType()
            : this(path => new LocalFileReference(path))
        {
            
        }

        public FileType(Func<string, IFile> factoryMethod)
        {
            CreateInstance = factoryMethod;
        }

        public Func<string, IFile> CreateInstance;

    }
}
