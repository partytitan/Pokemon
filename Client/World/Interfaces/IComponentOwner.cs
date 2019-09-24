using System.Collections.Generic;

namespace Client.World.Interfaces
{
    internal interface IComponentOwner
    {
        string Id { get; }
        T GetComponent<T>() where T : IComponent;
        List<T> GetComponents<T>() where T : IComponent;
    }
}
