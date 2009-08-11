using System;

namespace Secretary
{
    public class Secretary
    {
        public string AlmaMater { get; set; }
        public string RootFolder { get; set; }
        public FileType FileTypeHandled { get; set; }
        public Type Specialization { get; set; }
        public Func<object, string> PathDelegate;
    }
}