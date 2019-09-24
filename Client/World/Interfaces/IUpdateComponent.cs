using Microsoft.Xna.Framework;

namespace Client.World.Interfaces
{
    internal interface IUpdateComponent : IComponent
    {
        void Update(GameTime gameTime);
    }
}
