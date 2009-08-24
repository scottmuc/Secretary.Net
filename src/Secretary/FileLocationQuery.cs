using System;
using System.Collections.Generic;
using System.Linq;

namespace Secretary
{
    public class FileLocationQuery : IFileLocationQuery, INamed
    {
        public FileType FileType { get; private set; }
        public string FileName { get; set; }
        public IList<Secretary> Secretaries { get; set;}

        public FileLocationQuery(FileType fileType)
        {
            this.FileType = fileType;
        }

        public INamed Named(string fileName)
        {
            FileName = fileName;
            return this;
        }

        public string For<TEntity>(TEntity entity)
        {
            var secretary = Secretaries.Where(s => (s as Secretary<TEntity>) != null)
                .Where(s => s.FileTypeHandled == FileType).SingleOrDefault();

            if (secretary == null)
                throw new NullReferenceException("No secretary trained to handle that request");

            var casted = (Secretary<TEntity>) secretary;
            casted.Entity = entity;

            return secretary.Locate(FileName).AbsoluteFilePath;

        }
    }
}
