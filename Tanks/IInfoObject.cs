using System;
using System.Drawing;
using System.ComponentModel;

namespace Tanks
{
    interface IInfoObject
    {
        string Value { get; set; }
        [Browsable(false)]
        bool ChangeValueAvailable { get; set; }
        Font TextFont { get; set; }
        Color TextColor { get; set; }
    }
}
