﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public interface IBuilder<T>
    {
       void Build(T arg);
    }
}
