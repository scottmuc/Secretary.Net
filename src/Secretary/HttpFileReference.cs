using System;

namespace Secretary
{
    public class HttpFileReference : IFile
    {
        private readonly Uri uri;


        public HttpFileReference(string path)
            : this(new Uri(path))
        {
            
        }

        public HttpFileReference(Uri uri)
        {
            this.uri = uri;
        }

        public string AbsoluteFilePath
        {
            get { return uri.AbsoluteUri; }
        }

        public string FolderName
        {
            get { return uri.AbsolutePath; }
        }

        public string FileName
        {
            get { return uri.Host; }
        }
    }
}