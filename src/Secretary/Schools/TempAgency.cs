namespace Secretary.Schools
{
    public class TempAgency : ISchool
    {
        public ISecretary GetTrainedSecretary()
        {
            return new Secretaries.Temp();
        }
    }
}
