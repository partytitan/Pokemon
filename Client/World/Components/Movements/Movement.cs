using Client.Services;
using Client.Services.World;
using Client.World.Components.Animations;
using Client.World.Components.Tiles;
using Client.World.Interfaces;
using GameLogic.Common;
using Microsoft.Xna.Framework;
using System;
using System.Linq;

namespace Client.World.Components.Movements
{
    internal abstract class Movement : Component, IUpdateComponent
    {
        private readonly float speed;
        protected Vector2 wantedPosition;
        public bool InMovement;
        private readonly AnimationWalking animationWalking;

        private readonly Camera camera;
        private IWorldData worldData;

        protected Movement(IComponentOwner owner, float speed, IWorldData worldData) : base(owner)
        {
            this.speed = speed;
            InMovement = false;
            animationWalking = new AnimationWalking(41, 51, 2, Directions.Down);
            this.camera = worldData.GetComponents<Camera>().FirstOrDefault();
            this.worldData = worldData;

            var sprite = Owner.GetComponent<Sprite>();
            this.camera?.LookAt(sprite.CurrentPosition);
        }

        public void Move(Directions direction)
        {
            var sprite = Owner.GetComponent<Sprite>();
            var wantedTilePosition = sprite.TilePosition + UtilityService.ConvertDirectionToVector(direction);

            if (Collision((int)(wantedTilePosition.X), (int)(wantedTilePosition.Y)))
            {
                sprite.DrawFrame = new Rectangle(0, (int)direction * sprite.DrawFrame.Height, sprite.DrawFrame.Width, sprite.DrawFrame.Height);
                wantedPosition = new Vector2(sprite.TilePosition.X * Tile.Width, sprite.TilePosition.Y * Tile.Height);
            }
            else
            {
                wantedPosition = new Vector2(wantedTilePosition.X * Tile.Width, wantedTilePosition.Y * Tile.Height);
            }

            InMovement = true;
            var animation = Owner.GetComponent<Animation>();
            animationWalking.ChangeDirection(direction);
            animation.PlayAnimation(animationWalking);

            if (CheckLedges((int)(wantedTilePosition.X), (int)(wantedTilePosition.Y), sprite.CurrentDirection))
            {
                wantedTilePosition += UtilityService.ConvertDirectionToVector(direction);
                wantedPosition = new Vector2(wantedTilePosition.X * Tile.Width, wantedTilePosition.Y * Tile.Height);
            }
        }
        private bool CheckLedges(int wantedXTilePosition, int wantedYTilePosition, Directions direction)
        {
            var collisionObjects = worldData.GetComponents<ILedgeCollisionComponent>();
            return collisionObjects != null && collisionObjects.Any(c => c.CheckLedgeDirection(wantedXTilePosition, wantedYTilePosition, direction));
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

        protected virtual void FinishMovement()
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