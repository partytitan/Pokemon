using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
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
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
