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

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFileLocationQuery : IFluentInterface
    {

    }


    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFolderLocationQuery : IFluentInterface
    {
        string For<TEntity>(TEntity entity);
    }
}