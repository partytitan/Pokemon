using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.World
{
    internal interface IUpdateComponent : IComponent
    {
        void Update(GameTime gameTime);
    }
}
