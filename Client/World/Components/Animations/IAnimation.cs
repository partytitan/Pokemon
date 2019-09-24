using Microsoft.Xna.Framework;

namespace Client.World.Components.Animations
{
    internal interface IAnimation
    {
        int AnimationSpeed { get; set; }

        Rectangle GetNewAnimationState();
    }
}