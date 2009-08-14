using System.Collections.Generic;

namespace Secretary
{
    public class FileLocator
    {
        public static IList<Secretary> Secretaries { get; private set; }

        public static void InitializeWith(IList<Secretary> trainedSecretaries)
        {
            Secretaries = trainedSecretaries;
        }

        public static ILocationQuery Find()
        {
            return Find(FileType.Default);
        }

        public static ILocationQuery Find(FileType fileType)
        {
            return new LocationQuery
            {
                FileType = fileType,
                Secretaries = Secretaries
            };
        }

    }
}
