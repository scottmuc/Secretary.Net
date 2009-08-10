using System;

namespace Secretary.UnitTests
{
    public class Enrollment
    {
        public Secretary Secretary;
        public Type Type;
        public FileType FileType;

        public void SpecializingIn<TENTITY>(FileType fileType)
        {
            Type = typeof(TENTITY);
            FileType = fileType;
        }
    }
}