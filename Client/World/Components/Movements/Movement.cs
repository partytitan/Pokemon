using Client.Common;
using Client.Services;
using Client.World.Components.Animations;
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Linq;
using Client.Screens;
using Client.Services.World;
using Client.World.Components.Tiles;

namespace Client.World.Components.Movements
{
    internal abstract class Movement : Component, IUpdateComponent
    {
        private readonly float speed;
        private Vector2 wantedPosition;
        protected bool InMovement;
        private readonly AnimationWalking animationWalking;

        private readonly Camera camera;

        protected Movement(IComponentOwner owner, float speed, IWorldData worldData) : base(owner)
        {
            this.speed = speed;
            InMovement = false;
            animationWalking = new AnimationWalking(41, 51, 2, Directions.Down);
            this.camera = worldData.GetComponents<Camera>().FirstOrDefault();

            var sprite = Owner.GetComponent<Sprite>();
            this.camera?.LookAt(sprite.CurrentPosition);
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
            if (Collision((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height)))
                wantedPosition = new Vector2(x,y);

            InMovement = true;
            animationWalking.ChangeDirection(direction);
            var animation = Owner.GetComponent<Animation>();
            animation.PlayAnimation(animationWalking);
        }

        private bool Collision(int wantedXTilePosition, int wantedYTilePostion)
        {
            var collision = Owner.GetComponent<Collision>();
            return collision != null && collision.CheckCollision<IPreMoveCollisionComponent>(wantedXTilePosition, wantedYTilePostion);
        }

        public virtual void Update(GameTime gameTime)
        {
            var sprite = Owner.GetComponent<Sprite>();
            this.camera.LookAt(sprite.CurrentPosition);

            if (!InMovement)
                return;

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
        }

        private void FinishMovement()
        {
            var sprite = Owner.GetComponent<Sprite>();
            sprite.UpdateTilePosition((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
            sprite.ResetPositionOffset();
            InMovement = false;
            var animation = Owner.GetComponent<Animation>();
            animation.StopAnimation();

            CheckWarp((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
        }

        private void CheckWarp(int wantedXTilePosition, int wantedYTilePostion)
        {
            var warp = Owner.GetComponent<Collision>();
            warp?.CheckCollision<IPostMoveCollisionComponent>(wantedXTilePosition, wantedYTilePostion);
        }
    }
}