namespace Secretary
{
    public interface ISecretary
    {
        string FolderManaging { get; set; }
        IFile GetFile(string fileName);
    }
}