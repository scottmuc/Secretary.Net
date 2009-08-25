using System.IO;

namespace Secretary
{
    public class LocalFolderReference : IFolder
    {
        private readonly DirectoryInfo directory;

        public LocalFolderReference(string folderPath)
            : this(new DirectoryInfo(folderPath))
        {
        }

        public LocalFolderReference(DirectoryInfo directory)
        {
            this.directory = directory;
        }

        public string AbsolutePath
        {
            get { return directory.FullName; }
        }
    }
}