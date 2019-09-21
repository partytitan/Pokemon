using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World
{
    internal interface IDrawComponent : IComponent
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
