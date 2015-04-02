using System;
using System.Drawing;

namespace Tanks
{
    public interface GameDynamicObject
    {
        void Tick();
        void Draw(Graphics g);
    }
}
