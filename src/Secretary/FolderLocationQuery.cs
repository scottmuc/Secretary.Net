using System;
using System.Collections.Generic;
using System.Linq;

namespace Secretary
{
    public class FolderLocationQuery : IFolderLocationQuery
    {
        public FileType FileType { get; private set; }
        public IList<Secretary> Secretaries { get; set; }

        public FolderLocationQuery(FileType fileType)
        {
            this.FileType = fileType;
        }

        public string For<TEntity>(TEntity entity)
        {
            var secretary = Secretaries.Where(s => (s as Secretary<TEntity>) != null)
                .Where(s => s.FileTypeHandled == FileType).SingleOrDefault();

            if (secretary == null)
                throw new NullReferenceException("No secretary trained to handle that request");

            var casted = (Secretary<TEntity>)secretary;
            casted.Entity = entity;

            return secretary.GetFolder().AbsolutePath;
        }
    }
}