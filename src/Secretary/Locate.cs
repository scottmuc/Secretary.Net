using System;
using System.Collections.Generic;

namespace Secretary
{
    /// <summary>
    /// This is the Static Gateway entrance to the File Locator API. Like a container, this class must
    /// be initialized and then can be used.
    /// </summary>
    public class Locate
    {
        /// <summary>
        /// Internal collection of trained secretaries
        /// </summary>
        private static IList<Secretary> Secretaries { get; set; }

        /// <summary>
        /// Responsability for training secretaries is external to this API gateway
        /// </summary>
        /// <param name="trainedSecretaries"></param>
        public static void InitializeWith(IList<Secretary> trainedSecretaries)
        {
            Secretaries = trainedSecretaries;
        }

        public static bool IsInitialized
        {
            get { return (Secretaries != null); }
        }

        private static void GuardAgainstUninitializedUsage()
        {
            if (!IsInitialized)
                throw new Exception("Must initialize Locate Secretary collection!");           
        }

        /// <summary>
        /// Entry API to file reference retrieval
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FileLocationQuery File(string fileName)
        {
            GuardAgainstUninitializedUsage();

            return new FileLocationQuery(fileName)
            {
                Secretaries = Secretaries
            };
        }

        /// <summary>
        /// Entry API to folder reference retrieval
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static FolderLocationQuery FolderForType(FileType fileType)
        {
            GuardAgainstUninitializedUsage();

            return new FolderLocationQuery(fileType)
            {
                Secretaries = Secretaries
            };            
        }
    }
}
