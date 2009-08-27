namespace Secretary
{
    /// <summary>
    /// A container class that holds all the specifications of a secretaries training.
    /// </summary>
    public class Enrollment : IEnrollment 
    {
        /// <summary>
        /// Secretary that is enrolled
        /// </summary>        
        public Secretary Secretary { get; set; }

        /// <summary>
        /// School of enrollment
        /// </summary>
        public School School { get; set; }

        /// <summary>
        /// FileType training specified
        /// </summary>
        public FileType FileType { get; set; }

        public IEnrolledFor SpecializingIn(FileType fileType)
        {
            FileType = fileType;
            return this;
        }

        /// <summary>
        /// Transforms a basic secretary into a specialized secretary
        /// </summary>
        /// <typeparam name="TEntity">Type of entity of the specialization</typeparam>
        public void For<TEntity>()
        {
            Secretary = new Secretary<TEntity>
            {
                EntityPathBuilder = School.Specializations.Get<TEntity>(FileType)
            };            
        }
    }


}