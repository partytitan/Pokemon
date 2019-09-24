using Microsoft.Xna.Framework;
using System;

namespace Client.Screens.ScreenTransitionEffects
{
    internal class ScreenTransitionEffectFadeOut : ScreenTransitionEffectFade
    {
        public ScreenTransitionEffectFadeOut(int screenWidth, int screenHeight, byte fadeStepCount) : base(screenWidth, screenHeight, fadeStepCount)
        {
        }

        public override void Start()
        {
            Alpha = 0;
            IsDone = false;
        }

        public override void Update(GameTime gameTime)
        {
            Alpha += FadeStepCount;
            if (Math.Abs(Alpha - 255) < 1)
                IsDone = true;
        }
    }
}