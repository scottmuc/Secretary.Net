using System;

namespace Secretary
{
    public class SpecializedSecretary<TEntity> : Secretary
    {
        public Type Specialization { get; set; }
        public Func<TEntity, string> pathDelegate;
    }
}