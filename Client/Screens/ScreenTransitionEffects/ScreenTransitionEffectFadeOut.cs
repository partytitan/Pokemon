using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.Screens.ScreenTransitionEffects
{
    class ScreenTransitionEffectFadeOut : ScreenTransitionEffectFade
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
