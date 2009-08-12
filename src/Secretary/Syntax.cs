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


    public interface ILocationQuery : IFluentInterface
    {
        INamed Named(string fileName);
    }

    public interface INamed : IFluentInterface
    {
        string For<TEntity>(TEntity entity);
    }
}