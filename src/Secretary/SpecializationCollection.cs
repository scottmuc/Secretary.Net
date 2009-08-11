using System;
using System.Collections.Generic;

namespace Secretary
{
    public class SpecializationCollection
    {
        private readonly IDictionary<SpecializationKey, object> specializations;
        public FileType DefaultFileType { get; set; }

        public SpecializationCollection()
            : this(new Dictionary<SpecializationKey, object>())
        {
            
        }

        private SpecializationCollection(IDictionary<SpecializationKey, object> specializations)
        {
            this.specializations = specializations;
            DefaultFileType = FileType.File;
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
