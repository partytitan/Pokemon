using System;
using System.Collections.Generic;
using System.Text;
using Client.World.Interfaces;
using GameLogic.Common;

namespace Client.World.Components.Tiles
{
    class LedgeCollision : Tile, ILedgeCollisionComponent, IPreMoveCollisionComponent
    {
        public Directions Direction { get; set; }
        public LedgeCollision(IComponentOwner owner, int xTilePosition, int yTilePosition, Directions directions) : base(owner, xTilePosition, yTilePosition)
        {
            this.Direction = directions;
        }

        public bool Collide(int xTilePosition, int yTilePosition)
        {
            return xTilePosition == XTilePosition && yTilePosition == YTilePosition;
        }

        public bool CheckLedgeDirection(int xTilePosition, int yTilePosition, Directions direction)
        {
            if (Collide(xTilePosition, yTilePosition))
                if(this.Direction == direction) 
                    return true;

            return false;
        }
    }
}
