using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public abstract class Strategy<Context,Obj> 
    {
        protected Context context;
        public abstract void Algorithm(Obj arg);
    }
}
