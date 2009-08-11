namespace Secretary.UnitTests
{
    public class Enrollment
    {
        public Secretary Secretary;
        public FileType FileType;

        public void SpecializingIn<TENTITY>()
        {
            this.SpecializingIn<TENTITY>(FileType);
        }

        public void SpecializingIn<TENTITY>(FileType fileType)
        {
            Secretary = new SpecializedSecretary<TENTITY>();
            FileType = fileType;
        }
    }
}