using System;

namespace Secretary
{
    public class Enrollment : IEnrollment 
    {
        public Secretary Secretary { get; set; }
        public FileType FileType { get; set; }
        public Type ForType { get; set; }

        public IEnrolledFor SpecializingIn(FileType fileType)
        {
            FileType = fileType;
            return this;
        }

        public void For<TEntity>()
        {
            ForType = typeof(TEntity);
        }
    }


}