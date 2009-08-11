namespace Secretary
{
    public class Enrollment
    {
        public Secretary Secretary { get; set; }
        public FileType FileType { get; set; }

        public void SpecializingIn<TENTITY>()
        {
            SpecializingIn<TENTITY>(FileType);
        }

        public void SpecializingIn<TENTITY>(FileType fileType)
        {
            Secretary = new SpecializedSecretary<TENTITY>();
            FileType = fileType;
        }
    }
}