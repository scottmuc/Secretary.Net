namespace Secretary
{
    public interface IFile
    {
        string AbsoluteFilePath { get; }
        string FolderName { get; }
        string FileName { get; }
    }
}