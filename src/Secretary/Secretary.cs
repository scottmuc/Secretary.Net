using System.IO;

namespace Secretary
{
    public class Secretary : ISecretary
    {
        public Secretary(string folderManaging)
        {
            this.FolderManaging = folderManaging;
        }

        public string FolderManaging { get; set; }

        public IFile GetFile(string fileName)
        {
            var absoluteFilePath = Path.Combine(FolderManaging, fileName);
            return new File(absoluteFilePath);
        }
    }
}
