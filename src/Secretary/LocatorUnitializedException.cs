using System;

namespace Secretary
{
    public class LocatorUnitializedException : ApplicationException
    {
        public LocatorUnitializedException()
            : this("Must initialize Locate Secretary collection!")
        {
            
        }

        public LocatorUnitializedException(string message)
            : base(message)
        {
        }
    }
}