using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.EventArg;
using Client.Inputs;
using Client.Screens;
using Client.Services.World;
using Client.World.Components.Animations;
using Client.World.Components.Tiles;
using Client.World.Interfaces;
using GameLogic.Common;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Client.World.Components.Movements
{
    internal class MovementPlayer : Movement
    {
        private readonly Input input;
        private readonly IWorldData worldData;

        public MovementPlayer(IComponentOwner owner, float speed, Input input, IWorldData worldData) : base(owner, speed, worldData)
        {
            this.input = input;
            this.worldData = worldData;
            this.input.NewInputEvent += OnNewInput;
        }

        private void OnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (InMovement)
                return;
            switch (newInputEventArgs.Inputs)
            {
                case GameLogic.Common.Inputs.Left:
                    Move(Directions.Left);
                    break;
                case GameLogic.Common.Inputs.Up:
                    Move(Directions.Up);
                    break;
                case GameLogic.Common.Inputs.Right:
                    Move(Directions.Right);
                    break;
                case GameLogic.Common.Inputs.Down:
                    Move(Directions.Down);
                    break;
                case GameLogic.Common.Inputs.None:
                    break;
                case GameLogic.Common.Inputs.A:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Update(GameTime gameTime)
        {
            input.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void FinishMovement()
        {
            var sprite = Owner.GetComponent<Sprite>();
            sprite.UpdateTilePosition((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
            sprite.ResetPositionOffset();
            InMovement = false;
            var animation = Owner.GetComponent<Animation>();
            animation.StopAnimation();

            CheckWarp((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
            CheckMapChange((int)(wantedPosition.X / Tile.Width), (int)(wantedPosition.Y / Tile.Height));
        }
        private void CheckWarp(int wantedXTilePosition, int wantedYTilePostion)
        {
            var warp = Owner.GetComponent<Collision>();
            warp?.CheckCollision<IPostMoveCollisionComponent>(wantedXTilePosition, wantedYTilePostion);
        }

        private void CheckMapChange(int wantedXTilePosition, int wantedYTilePosition)
        {
            var camera = worldData.GetComponents<Camera>().FirstOrDefault();
            if (wantedXTilePosition < 0)
            {
                worldData.WarpData.XMapId--;
                worldData.WarpData.XWarpPosition = worldData.MapLoader.MapLeft.Width - 1;
                worldData.WarpData.YWarpPosition = wantedYTilePosition + (Convert.ToInt16(worldData.MapLoader.CurrentMap.Properties["yOffsetModifier"]) - Convert.ToInt16(worldData.MapLoader.MapLeft.Properties["yOffsetModifier"])) / (Tile.Width * 2);
                worldData.ChangeMap(worldData.WarpData);
            }
            else if (wantedYTilePosition < 0)
            {
                worldData.WarpData.YMapId--;
                worldData.WarpData.XWarpPosition = wantedXTilePosition + (Convert.ToInt16(worldData.MapLoader.CurrentMap.Properties["xOffsetModifier"]) - Convert.ToInt16(worldData.MapLoader.MapUp.Properties["xOffsetModifier"])) / (Tile.Width * 2);
                worldData.WarpData.YWarpPosition = worldData.MapLoader.MapUp.Height - 1;
                worldData.ChangeMap(worldData.WarpData);
            }
            else if (wantedXTilePosition > camera?.MapBounds.X / Tile.Width)
            {
                worldData.WarpData.XMapId++;
                worldData.WarpData.XWarpPosition = 0;
                worldData.WarpData.YWarpPosition = wantedYTilePosition + (Convert.ToInt16(worldData.MapLoader.CurrentMap.Properties["yOffsetModifier"]) - Convert.ToInt16(worldData.MapLoader.MapRight.Properties["yOffsetModifier"])) / (Tile.Width * 2);
                worldData.ChangeMap(worldData.WarpData);
            }
            else if (wantedYTilePosition > camera?.MapBounds.Y / Tile.Height)
            {
                worldData.WarpData.YMapId++;
                worldData.WarpData.XWarpPosition = wantedXTilePosition + (Convert.ToInt16(worldData.MapLoader.CurrentMap.Properties["xOffsetModifier"]) - Convert.ToInt16(worldData.MapLoader.MapDown.Properties["xOffsetModifier"])) / (Tile.Width * 2);
                worldData.WarpData.YWarpPosition = 1;
                worldData.ChangeMap(worldData.WarpData);
            }
        }
    }
}
