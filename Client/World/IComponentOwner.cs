using System;
using System.Collections.Generic;
using System.Text;

namespace Client.World
{
    internal interface IComponentOwner
    {
        string Id { get; }
        T GetComponent<T>() where T : Component;
    }
}
