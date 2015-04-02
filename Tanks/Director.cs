using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public abstract class Director<T> where T:new()
    {
        public virtual T Construct(IBuilder<T>[] builders)
        {
            T result = new T();
            foreach (IBuilder<T> b in builders)
            {
                b.Build(result);
            }
            return result;
        }
    }
}
