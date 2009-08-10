using System.IO;

namespace Secretary.FileReferences
{
    /// <summary>
    /// Concrete File class for a local filesystem reference
    /// </summary>
    public class LocalFileReference : IFile
    {
        private readonly FileInfo fileInfo;

        public LocalFileReference(string absoluteFilePath)
            : this(new FileInfo(absoluteFilePath))
        {
        }

        public LocalFileReference(FileInfo fileInfo)
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