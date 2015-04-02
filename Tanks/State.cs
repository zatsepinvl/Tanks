using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public abstract class State<T>
    {
        protected T context;
        public abstract void ChangeState();
        public abstract string GetState();
    }
}
