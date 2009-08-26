namespace Secretary
{
    public class WebLocation : Location
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
            return firstPart.TrimEnd('/') + "/" + secondPart.TrimStart('/');
        }        
    }
}
