using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Client.World
{
    internal interface IWorldObject
    {
        int ZTilePosition { get; }
        void LoadContent(IContentLoader contentLoader);
        void Update(GameTime gameTime, OrthographicCamera camera);
        void Draw(SpriteBatch spriteBatch);
    }
}
