using Client.World.Interfaces;
using Microsoft.Xna.Framework;

namespace Client.World.Components.Animations
{
    internal class Animation : Component, IUpdateComponent
    {
        private IAnimation currentAnimation;
        private double counter;

        public Animation(IComponentOwner owner) : base(owner)
        {
            counter = 0;
        }

        public Animation(IComponentOwner owner, IAnimation animation) : this(owner)
        {
            currentAnimation = animation;
        }

        public void Update(GameTime gameTime)
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