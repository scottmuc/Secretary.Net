namespace Secretary
{
    /// <summary>
    /// I purposely put very little logic in the Secretary class. This class is
    /// responsible for holding instructions from it's training and acting upon
    /// those instructions when asked.
    /// </summary>
    public class Secretary
    {
        public string AlmaMater { get; set; }
        public string RootFolder { get; set; }
        public FileType FileTypeHandled { get; set; }
        public Location LocationContext { get; set; }

        public virtual IFile Locate(string fileName)
        {
            return LocationContext.CreateFileInstance(RootFolder, fileName);
        }

        public virtual IFolder GetFolder()
        {
            return LocationContext.CreateFolderInstance(RootFolder);
        }
    }
}
