using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Screens.ScreenTransitionEffects
{
    internal interface IScreenTransitionEffect
    {
        bool IsDone { get; }

        void Start();

        void LoadContent(IContentLoader contentLoader);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}