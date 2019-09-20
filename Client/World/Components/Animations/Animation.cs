using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Client.World.Components.Animations
{
    internal class Animation : Component
    {
        private IAnimation currentAnimation;
        private double counter;

        public Animation(IComponentOwner owner) : base(owner)
        {
            counter = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (currentAnimation == null)
                return;
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > currentAnimation.AnimationSpeed)
            {
                var drawFrame = currentAnimation.GetNewAnimationState();
                var sprite = Owner.GetComponent<Sprite>();
                sprite.UpdateDrawFrame(drawFrame);
                counter = 0;
            }
        }

        public void PlayAnimation(IAnimation animation)
        {
            currentAnimation = animation;
        }

        public void StopAnimation()
        {
            currentAnimation = null;
        }
    }
}
