using System;
using System.Collections.Generic;
using System.Text;

namespace Client.World
{
    internal interface IComponent
    {
        bool Killed { get; }
    }
}
