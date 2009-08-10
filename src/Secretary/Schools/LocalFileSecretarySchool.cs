namespace Secretary.Schools
{
    public class LocalFileSecretarySchool : ISchool
    {
        private readonly string schoolSpecializedFolder;

        public LocalFileSecretarySchool(string schoolSpecializedFolder)
        {
            this.schoolSpecializedFolder = schoolSpecializedFolder;
        }

        public ISecretary GetTrainedSecretary()
        {
            return new Secretaries.LocalFileSecretary(schoolSpecializedFolder);
        }
    }
}