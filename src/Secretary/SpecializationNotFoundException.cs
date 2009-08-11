using System;

namespace Secretary
{
    public class SpecializationNotFoundException : Exception
    {
        public SpecializationNotFoundException(SpecializationKey key)
            : base(string.Format("Could not find specialization for {0}:{1}", key.SpecializationType, key.FileType))
        {
            
        }
    }
}