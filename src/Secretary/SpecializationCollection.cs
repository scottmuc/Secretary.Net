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
        }

        public void Add<TENTITY>(Func<TENTITY, string> pathDelegate)
        {
            this.Add(DefaultFileType, pathDelegate);
        }

        public void Add<TENTITY>(FileType fileType, Func<TENTITY, string> pathDelegate)
        {
            var key = new SpecializationKey(typeof(TENTITY), fileType);
            specializations.Add(key, pathDelegate);
        }
    }
}