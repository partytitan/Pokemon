using Client.Services.Content;
using Client.Services.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Screens
{
    public abstract class Screen
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