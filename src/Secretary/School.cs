namespace Secretary
{
    public class School : ISchool
    {
        private readonly string schoolSpecializedFolder;

        public School(string schoolSpecializedFolder)
        {
            this.schoolSpecializedFolder = schoolSpecializedFolder;
        }

        public void Train(ref ISecretary secretary)
        {
            secretary.FolderManaging = schoolSpecializedFolder;
        }
    }
}
