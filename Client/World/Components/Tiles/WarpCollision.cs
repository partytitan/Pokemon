using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.Services.World;

namespace Client.World.Components.Tiles
{
    class WarpCollision : Tile, IPostMoveCollisionComponent
    {
        private readonly IWorldData worldData;
        private readonly WarpData warpData;

        public WarpCollision(IComponentOwner owner, WarpData warpData, IWorldData worldData) : base(owner, warpData.XTilePosition, warpData.YTilePosition)
        {
            this.warpData = warpData;
            this.worldData = worldData;
        }
        public bool Collide(int xTilePosition, int yTilePosition)
        {
            if (warpData.XTilePosition == xTilePosition && warpData.YTilePosition == yTilePosition)
            {
                worldData.ChangeMap(warpData);
                return true;
            }

            return false;
        }
    }
}
