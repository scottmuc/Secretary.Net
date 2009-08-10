using System.IO;
using Secretary.FileReferences;

namespace Secretary.Secretaries
{
    public class LocalFileSecretary : ISecretary
    {
        public LocalFileSecretary(string folderManaging)
        {
            this.FolderManaging = folderManaging;
        }

        public string FolderManaging { get; set; }

        public IFile GetFile(string fileName)
        {
            var absoluteFilePath = Path.Combine(FolderManaging, fileName);
            return new LocalFileReference(absoluteFilePath);
        }
    }
}