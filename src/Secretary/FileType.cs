using System;

namespace Secretary
{
    public class FileType
    {
        public static FileType File = new FileType("File");
        public static FileType Image = new FileType("Image");
        public static FileType Audio = new FileType("Audio");

        public FileType(string name)
            : this(name, path => new LocalFileReference(path))
        {
            
        }

        public FileType(string name, Func<string, IFile> factoryMethod)
        {
            Name = name;
            CreateInstance = factoryMethod;
        }

        public Func<string, IFile> CreateInstance;
        public string Name { get; private set; }

        public override string ToString() 
        {
            return Name;
        }

    }
}
