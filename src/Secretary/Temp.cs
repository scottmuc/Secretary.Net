using System.IO;

namespace Secretary
{
    /// <summary>
    /// A Temp secretary is specialized in handling temporary files.
    /// </summary>
    public class Temp : Secretary
    {
        /// <remark>
        /// The GetTempPath function checks for the existence of environment
        ///  variables in the following order and uses the first path found:        
        ///   1. The path specified by the TMP environment variable.
        ///   2. The path specified by the TEMP environment variable.
        ///   3. The path specified by the USERPROFILE environment variable.
        ///   4. The Windows directory.
        /// </remark>
        public Temp()
            : base(Path.GetTempPath())
        {

        }
    }
}