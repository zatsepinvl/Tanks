using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class Engine:TextureObject
    {
        public int Power { get; set; }
        public int Weight { get; set; }
        public int Volume { get; set; }
        public Engine() { }
    }
}
