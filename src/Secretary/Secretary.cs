namespace Secretary
{
    public class Secretary : ISecretary
    {
        public Secretary(string folderManaging)
        {
            this.FolderManaging = folderManaging;
        }

        public string FolderManaging { get; set; }
    }
}