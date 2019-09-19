using System;
using System.Collections.Generic;
using System.Text;
using Client.Common;
using Client.Services;
using Client.World.Components.Animations;
using Client.World.Tiles;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Client.World.Components.Movements
{
    internal abstract class Movement : Component
    {
        private readonly float speed;
        protected Vector2 wantedPosition;
        protected bool InMovement;
        private readonly AnimationWalking animationWalking;

        protected Movement(IComponentOwner owner, float speed) : base(owner)
        {
            this.speed = speed;
            InMovement = false;
            animationWalking = new AnimationWalking(41, 51, 2, Directions.Down);
        }

        protected void Move(Directions direction)
        {
            var sprite = Owner.GetComponent<Sprite>();
            var x = sprite.TilePosition.X * Tile.Width;
            var y = sprite.TilePosition.Y * Tile.Height;
            switch (direction)
            {
                case Directions.Left:
                    wantedPosition = new Vector2(x - Tile.Width, y);
                    break;
                case Directions.Up:
                    wantedPosition = new Vector2(x, y - Tile.Height);
                    break;
                case Directions.Right:
                    wantedPosition = new Vector2(x + Tile.Width, y);
                    break;
                case Directions.Down:
                    wantedPosition = new Vector2(x, y + Tile.Height);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            InMovement = true;
            animationWalking.ChangeDirection(direction);
            var animation = Owner.GetComponent<Animation>();
            animation.PlayAnimation(animationWalking);
        }

        public override void Update(GameTime gameTime, OrthographicCamera camera)
        {
            if (!InMovement)
                return;
            var sprite = Owner.GetComponent<Sprite>();
            var currentPosition = sprite.CurrentPosition;
            if (UtilityService.GetDistance(currentPosition, wantedPosition) < speed)
            {
                FinishMovement();
            }
            if (currentPosition.X < wantedPosition.X)
            {
                sprite.IncreasePositionOffset(speed, 0);
            }
            if (currentPosition.X > wantedPosition.X)
            {
                sprite.IncreasePositionOffset(speed * -1, 0);
            }
            if (currentPosition.Y < wantedPosition.Y)
            {
                sprite.IncreasePositionOffset(0, speed);
            }
            if (currentPosition.Y > wantedPosition.Y)
            {
                sprite.IncreasePositionOffset(0, speed * -1);
            }
            camera.LookAt(sprite.CurrentPosition);
        }

        private void FinishMovement()
        {
            var sprite = Owner.GetComponent<Sprite>();
            sprite.UpdateTilePosition((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
            sprite.ResetPositionOffset();
            InMovement = false;
            var animation = Owner.GetComponent<Animation>();
            animation.StopAnimation();
        }
    }
}
