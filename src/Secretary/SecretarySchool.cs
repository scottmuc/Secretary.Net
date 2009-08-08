namespace Secretary
{
    public class SecretarySchool
    {
        public ISecretary TrainFor(string folderToManage)
        {
            return new Secretary(folderToManage);
        }
    }
}