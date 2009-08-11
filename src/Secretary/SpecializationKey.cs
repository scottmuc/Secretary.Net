using System;

namespace Secretary
{
    public class SpecializationKey
    {
        private readonly int hash;

        public Type SpecializationType { get; private set; }
        public FileType FileType { get; private set; }

        public SpecializationKey(Type entityType, FileType fileType)
        {           
            FileType = fileType;
            SpecializationType = entityType;

            hash = entityType.GetHashCode() ^ fileType.GetHashCode();
        }

        public bool Equals(SpecializationKey other)
        {
            return SpecializationKey.Equals(this, other);
        }

        public override bool Equals(object other)
        {
            return SpecializationKey.Equals(this, other as SpecializationKey);
        }

        public static bool Equals(SpecializationKey obj1, SpecializationKey obj2)
        {
            if (Object.Equals(null, obj1) || Object.Equals(null, obj2))
                return false;

            return obj1.SpecializationType == obj2.SpecializationType
                && obj1.FileType == obj2.FileType;  
        }

        public override int GetHashCode()
        {
            return hash;
        }

    }
}