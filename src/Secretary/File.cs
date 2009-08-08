using System.IO;

namespace Secretary
{
    public class File : IFile
    {
        private readonly FileInfo fileInfo;

        public File(string absoluteFilePath)
            : this(new FileInfo(absoluteFilePath))
        {
        }

        public File(FileInfo fileInfo)
        {
            this.fileInfo = fileInfo;
        }

        public string FolderName
        {
            get { return fileInfo.DirectoryName; }
        }

        public string AbsoluteFilePath
        {
            get { return fileInfo.FullName; }
        }

        public string FileName
        {
            get { return fileInfo.Name; }
        }
    }
}