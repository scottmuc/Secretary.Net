using System;

namespace Secretary.UnitTests
{
    public class SpecializedSecretary : Secretary
    {
        public Type Specialization { get; set; }
    }
}