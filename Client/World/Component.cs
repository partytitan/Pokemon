using Client.World.Interfaces;

namespace Client.World
{
    internal abstract class Component : IComponent
    {
        protected readonly IComponentOwner Owner;
        public bool Killed { get; protected set; }

        protected Component(IComponentOwner owner)
        {
            Owner = owner;
        }
    }
}