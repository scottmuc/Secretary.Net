namespace Secretary
{
    public class HttpLocation : Location
    {
        public override IFile CreateFileInstance(string basePath, string fileName)
        {
            var fullPath = Combine(basePath, fileName);
            return new HttpFileReference(fullPath);
        }

        public override IFolder CreateFolderInstance(string basePath)
        {
            return new HttpFolderReference(basePath);
        }

        public override string Combine(string firstPart, string secondPart)
        {
            var normalizedFirstPart = firstPart.TrimEnd('/').Replace('\\', '/');
            var normalizedSecondPart = secondPart.TrimStart('/').Replace('\\', '/');
            return normalizedFirstPart + "/" + normalizedSecondPart;
        }        
    }
}
