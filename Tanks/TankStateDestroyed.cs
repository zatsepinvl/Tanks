using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class TankStateDestroyed:TankState
    {
        public TankStateDestroyed(Tank context) : base(context) { }
        public override void ChangeState()
        {
            context.Speed = 0;
            context.Health = 0;
        }
       
    }
}
