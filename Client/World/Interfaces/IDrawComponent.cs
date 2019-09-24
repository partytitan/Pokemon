using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Interfaces
{
    internal interface IDrawComponent : IComponent
    {
        void Draw(SpriteBatch spriteBatch);
    }
}