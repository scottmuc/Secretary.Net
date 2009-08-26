using System;

namespace Secretary
{
    public class FileLocationQuery : LocationQueryBase, IFileLocationQuery
    {
        public string FileName { get; private set; }

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
            var secretary = GetSecretary<TEntity>();

            if (secretary == null)
                throw new NullReferenceException("No secretary trained to handle that request");

            var casted = (Secretary<TEntity>) secretary;
            casted.Entity = entity;
            return secretary.Locate(FileName).AbsoluteFilePath;
        }
    }
}
