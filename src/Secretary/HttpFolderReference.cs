using System;

namespace Secretary
{
    public class HttpFolderReference : IFolder
    {
        private readonly Uri uri;

        public HttpFolderReference(string basePath)
            : this(new Uri(basePath))
        {
            
        }

        public HttpFolderReference(Uri uri)
        {
            this.uri = uri;
        }

        public string AbsolutePath
        {
            get { return uri.AbsoluteUri; }
        }
    }
}