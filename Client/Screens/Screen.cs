using Client.Services.Content;
using Client.Services.Screens;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Client.Screens
{
    internal abstract class Screen
    {
        protected readonly IScreenLoader ScreenLoader;

        protected Screen(IScreenLoader screenLoader)
        {
            this.ScreenLoader = screenLoader;
        }

        public abstract void LoadContent(IContentLoader contentLoader);
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
