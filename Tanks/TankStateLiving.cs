using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class TankStateLiving : TankState
    {
        const int burningHealthRate = 10;
        public TankStateLiving(Tank context)
            : base(context)
        {
            context.HealthChanged += ContextHealthChanged;
        }

        void ContextHealthChanged(Tank obj)
        {
            ChangeState();
        }
        public override void ChangeState()
        {
            if ((context.Health > 0) && (context.Health < burningHealthRate))
            {
                context.HealthChanged -= ContextHealthChanged;
                context.State = new TankStateBurning(context);
            }
            else if (context.Health <= 0)
            {
                context.HealthChanged -= ContextHealthChanged;
                context.State = new TankStateDestroyed(context);
            }
        }
    }
}
