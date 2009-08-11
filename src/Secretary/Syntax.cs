namespace Secretary
{
    public interface IEnrollment : IFluentInterface, IEnrolledFor
    {
        IEnrolledFor SpecializingIn(FileType fileType);   
    }

    public interface IEnrolledFor : IFluentInterface
    {
        void For<TEntity>();
    }
}