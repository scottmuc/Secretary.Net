using System.Collections.Generic;
using System.Linq;

namespace Secretary
{
    public class LocationQueryBase
    {
        protected FileType FileType { get; set; }
        protected Location LocationContext { get; set; }
        public IList<Secretary> Secretaries { get; set; }
    
        protected Secretary GetSecretary<TEntity>()
        {
            return Secretaries
                    .Where(s => (s as Secretary<TEntity>) != null)
                    .Where(s => s.FileTypeHandled == FileType)
                    .Where(s => s.LocationContext == LocationContext)
                .SingleOrDefault();
        }

    }
}
