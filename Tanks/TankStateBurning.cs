using System;
using System.Timers;
using System.Text;

namespace Tanks
{
    public class TankStateBurning:TankState
    {
        const int burningTime = 30000;
        const double tankSpeed = 2;
        public TankStateBurning(Tank context) : base(context) 
        {
            Timer t = new Timer(burningTime);
            t.Elapsed += new ElapsedEventHandler(TimerElapsed);
            context.HealthChanged += ContextHealthChanged;
            context.Speed = 10;
            t.Start();
        }

        void ContextHealthChanged(Tank obj)
        {
            ChangeState();
        }

        void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Stop();
            context.Health = 0;
            ChangeState();
        }
        public override void ChangeState()
        {
            if ((context.Health <= 0)&&(context.State==this))
            {
                context.HealthChanged -= ContextHealthChanged;
                context.State = new TankStateDestroyed(context);
            }
        }
    }
}
