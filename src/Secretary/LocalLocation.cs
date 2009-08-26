using System.IO;

namespace Secretary
{
    public class LocalLocation : Location
    {

        public override IFile CreateFileInstance(string basePath, string fileName)
        {
            var fullPath = Combine(basePath, fileName);
            return new LocalFileReference(fullPath);            
        }

        public override IFolder CreateFolderInstance(string basePath)
        {
            return new LocalFolderReference(basePath);
        }

        public override string Combine(string firstPart, string secondPart)
        {
            return Path.Combine(firstPart, secondPart);
        }
    }
}
