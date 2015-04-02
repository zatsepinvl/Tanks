using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class TankState:State<Tank>
    {
        public TankState(Tank context)
        {
            this.context = context;
        }
        public override void ChangeState()
        {
            throw new NotImplementedException();
        }
        public override string GetState()
        {
            return this.GetType().Name;
        }
    }
}
