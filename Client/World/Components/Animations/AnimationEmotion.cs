using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.World.Components.Animations
{
    internal class AnimationEmotion : IAnimation
    {
        private const int Width = 16;
        private const int Height = 16;
        private int animationindex;
        public int AnimationSpeed { get; set; }

        public AnimationEmotion()
        {
            AnimationSpeed = 25;
            animationindex = 0;
        }

        public Rectangle GetNewAnimationState()
        {
            if (animationindex < 2)
            {
                animationindex++;
            }
            return new Rectangle(Width * animationindex, 0, Width, Height);
        }
    }
}
