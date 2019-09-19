using Client.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Screens.ScreenTransitionEffects
{
    interface IScreenTransitionEffect
    {
        bool IsDone { get; }
        void Start();
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
