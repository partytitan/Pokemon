using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Screens.ScreenTransitionEffects
{
    internal abstract class ScreenTransitionEffectFade : IScreenTransitionEffect
    {
        protected int FadeStepCount;
        protected int Alpha;
        private readonly Rectangle backgroundRectangle;
        private Texture2D backgroundTexture;
        public bool IsDone { get; protected set; }

        protected ScreenTransitionEffectFade(int screenWidth, int screenHeight, int fadeStepCount)
        {
            backgroundRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            FadeStepCount = fadeStepCount;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            backgroundTexture = contentLoader.LoadTexture("ScreenEffects/white_block");
        }

        public abstract void Start();
        public abstract void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsDone)
                return;
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, new Color(0, 0, 0, Alpha));
        }
    }
}
