using System.Collections.Generic;

namespace Secretary
{
    public class Locate
    {
        public static IList<Secretary> Secretaries { get; private set; }

        public static void InitializeWith(IList<Secretary> trainedSecretaries)
        {
            Secretaries = trainedSecretaries;
        }

        public static IFileLocationQuery FileOfType(FileType fileType)
        {
            return new FileLocationQuery(fileType)
            {
                Secretaries = Secretaries
            };
        }

        public static IFolderLocationQuery FolderForType(FileType fileType)
        {
            return new FolderLocationQuery(fileType)
            {
                Secretaries = Secretaries
            };
            
        }
    }
}
