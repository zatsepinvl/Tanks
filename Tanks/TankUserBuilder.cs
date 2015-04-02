using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Tanks
{
    public class TankUserBuilder:IBuilder<Tank>
    {
        Control control;
        public TankUserBuilder(Control control)
        {
            this.control = control;
        }
        public void Build(Tank arg)
        {
            arg.Strategy = new UserStrategy(arg, null, control);
        }
    }
}
