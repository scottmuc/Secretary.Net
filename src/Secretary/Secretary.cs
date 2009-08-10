namespace Secretary
{
    public class Secretary
    {

        public static ISchool TempAgency { get; set; }


        public static IFile LocateFile(string fileName)
        {
            var secretary = TempAgency.GetTrainedSecretary();

            return secretary.GetFile(fileName);
        }
    }
}