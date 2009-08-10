namespace Secretary
{
    /// <summary>
    /// Base abstraction for any file. This interface makes no assumptions about where
    /// a file is located or it's type.
    /// </summary>
    public interface IFile
    {
        string AbsoluteFilePath { get; }
        string FolderName { get; }
        string FileName { get; }
    }
}