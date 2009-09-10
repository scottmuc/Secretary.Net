using System.ComponentModel;

// Influence by Funq Screencasts
// http://www.clariusconsulting.net/blogs/kzu/archive/2009/02/02/116399.aspx
namespace Secretary
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEnrollment : ISpecializedIn, IEnrolledFor { }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IEnrolledFor : IFluentInterface
    {
        void For<TEntity>();
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface ISpecializedIn : IFluentInterface
    {
        IEnrolledFor SpecializingIn(FileType fileType);  
    }


    /// <summary>
    /// Beginning of a file location query
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFileLocationQuery : IFluentInterface
    {
        IInLocation Of(FileType fileType);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IInLocation : IFluentInterface
    {
        IForEntity In(Location fileLocation);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IForEntity : IFluentInterface
    {
        string For<TEntity>(TEntity entity);
    }


    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFolderLocationQuery : IFluentInterface
    {
        IForEntity In(Location fileLocation);
    }
}