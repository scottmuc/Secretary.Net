using System;

namespace Secretary
{
    public class Enrollment : IEnrollment 
    {
        public Secretary Secretary { get; set; }
        public School School { get; set; }
        public FileType FileType { get; set; }
        public Type ForType { get; set; }        

        public IEnrolledFor SpecializingIn(FileType fileType)
        {
            FileType = fileType;
            return this;
        }

        public void For<TEntity>()
        {
            Secretary = new Secretary<TEntity>
            {
                EntityPathBuilder = School.Specializations.Get<TEntity>(FileType)
            };
            
            ForType = typeof(TEntity);
        }
    }


}