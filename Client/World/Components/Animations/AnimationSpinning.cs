using GameLogic.Common;
using Microsoft.Xna.Framework;

namespace Client.World.Components.Animations
{
    internal class AnimationSpinning : IAnimation
    {
        private readonly int width;
        private readonly int height;
        private readonly int[] directions;
        private int currentDirectionIndex;
        public int AnimationSpeed { get; set; }

        public AnimationSpinning(int width, int height, int animationCooldown)
        {
            this.width = width;
            this.height = height;
            AnimationSpeed = animationCooldown;
            directions = new[]
            {
                (int) Directions.Left,
                (int) Directions.Up,
                (int) Directions.Right,
                (int) Directions.Down
            };
        }

        public Rectangle GetNewAnimationState()
        {
            currentDirectionIndex++;
            if (currentDirectionIndex > 3)
            {
                currentDirectionIndex = 0;
            }
            return new Rectangle(width, height * directions[currentDirectionIndex], width, height);
        }
    }
}