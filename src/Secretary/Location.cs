using System;

namespace Secretary
{
    public class Location
    {
        public static readonly Location Web = new Location("Web", path => new HttpFileReference(path));
        public static readonly Location Local = new Location("Local", path => new LocalFileReference(path));


        public Location(string name, Func<string, IFile> factoryMethod)
        {
            Name = name;
            CreateInstance = factoryMethod;
        }

        public Func<string, IFile> CreateInstance;
        public string Name { get; private set; }

        public override string ToString()
        {
            return "Location." + Name;
        }
    }
}
