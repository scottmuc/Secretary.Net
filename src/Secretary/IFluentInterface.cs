using System;
using System.ComponentModel;

namespace Secretary
{
    /// <summary>
    /// Based on the fluent interface API design by Daniel Cazzulino
    /// http://www.clariusconsulting.net/blogs/kzu/archive/2008/03/10/58301.aspx
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFluentInterface
    {
        /// <summary/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        /// <summary/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <summary/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        /// <summary/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    }

}
