namespace Secretary
{
    public abstract class Location
    {
        public static readonly Location Web = new WebLocation();
        public static readonly Location Local = new LocalLocation();

        public abstract IFile CreateFileInstance(string basePath, string fileName);
        public abstract IFolder CreateFolderInstance(string basePath);
        public abstract string Combine(string firstPart, string secondPart);
    }
}
