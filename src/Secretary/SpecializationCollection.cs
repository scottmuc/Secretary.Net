using System;
using System.Collections.Generic;

namespace Secretary
{
    /// <summary>
    /// Used to store a collection of path construction delegates keyed to an Entity and a FileType
    /// </summary>
    public class SpecializationCollection
    {
        private readonly IDictionary<SpecializationKey, object> specializations;
        private FileType DefaultFileType { get; set; }

        public SpecializationCollection()
            : this(new Dictionary<SpecializationKey, object>(), FileType.Default)
        {
            
        }

        protected SpecializationCollection(IDictionary<SpecializationKey, object> specializations, FileType defaultFileType)
        {
            this.specializations = specializations;
            this.DefaultFileType = defaultFileType;
        }

        public void Add<TENTITY>(Func<TENTITY, string> pathDelegate)
        {
            Add(DefaultFileType, pathDelegate);
        }

        public void Add<TEntity>(FileType fileType, Func<TEntity, string> pathDelegate)
        {
            var key = new SpecializationKey(typeof(TEntity), fileType);
            specializations.Add(key, pathDelegate);
        }

        public bool Contains<TEntity>()
        {
            return Contains<TEntity>(DefaultFileType);
        }

        public bool Contains<TEntity>(FileType fileType)
        {
            var key = new SpecializationKey(typeof(TEntity), fileType);
            return specializations.ContainsKey(key);
        }

        public Func<TEntity, string> Get<TEntity>(FileType fileType)
        {
            var key = new SpecializationKey(typeof(TEntity), fileType);

            if (!Contains<TEntity>(fileType))
                throw new SpecializationNotFoundException(key);

            return (Func<TEntity, string>) specializations[key];
        }
    }
}
