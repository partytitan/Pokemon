using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Screens.ScreenTransitionEffects
{
    internal class ScreenTransitionEffectFadeIn : ScreenTransitionEffectFade
    {
        public ScreenTransitionEffectFadeIn(int screenWidth, int screenHeight, int fadeStepCount) : base(screenWidth, screenHeight, fadeStepCount)
        {
        }

        public override void Start()
        {
            Alpha = 255;
            IsDone = false;
        }

        public override void Update(double gameTime)
        {
            Alpha -= FadeStepCount;
            if (Math.Abs(Alpha) < 1)
                IsDone = true;
        }
    }
}
