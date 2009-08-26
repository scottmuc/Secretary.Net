using System;
using System.Collections.Generic;
using System.Linq;

namespace Secretary
{
    public class FileLocationQuery : IFileLocationQuery
    {
        public FileType FileType { get; private set; }
        public Location LocationContext { get; private set; }
        public string FileName { get; private set; }
        public IList<Secretary> Secretaries { get; set;}

        public FileLocationQuery(string fileName)
        {
            FileName = fileName;
        }

        public FileLocationQuery Of(FileType fileType)
        {
            FileType = fileType;
            return this;
        }

        public FileLocationQuery In(Location location)
        {
            LocationContext = location;
            return this;
        }

        public string For<TEntity>(TEntity entity)
        {
            var secretary = Secretaries
                    .Where(s => (s as Secretary<TEntity>) != null)
                    .Where(s => s.FileTypeHandled == FileType)
                    .Where(s => s.LocationContext == LocationContext)
                .SingleOrDefault();

            if (secretary == null)
                throw new NullReferenceException("No secretary trained to handle that request");

            var casted = (Secretary<TEntity>) secretary;
            casted.Entity = entity;
            return secretary.Locate(FileName).AbsoluteFilePath;
        }
    }
}
