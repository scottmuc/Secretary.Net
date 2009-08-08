namespace Secretary
{
    public class School : ISchool
    {
        private readonly string schoolSpecializedFolder;

        public School(string schoolSpecializedFolder)
        {
            this.schoolSpecializedFolder = schoolSpecializedFolder;
        }

        public ISecretary GetTrainedSecretary()
        {
            return new Secretary(schoolSpecializedFolder);
        }
    }
}
