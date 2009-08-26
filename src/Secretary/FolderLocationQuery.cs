using System;

namespace Secretary
{
    public class FolderLocationQuery : LocationQueryBase, IFolderLocationQuery
    {
        public FolderLocationQuery(FileType fileType)
        {
            this.FileType = fileType;
        }

        public FolderLocationQuery In(Location location)
        {
            this.LocationContext = location;
            return this;
        }

        public string For<TEntity>(TEntity entity)
        {
            var secretary = GetSecretary<TEntity>();

            if (secretary == null)
                throw new NullReferenceException("No secretary trained to handle that request");

            var casted = (Secretary<TEntity>)secretary;
            casted.Entity = entity;

            return secretary.GetFolder().AbsolutePath;
        }
    }
}
