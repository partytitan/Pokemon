using Client.World.Interfaces;

namespace Client.World.Components.Tiles
{
    class TileCollision : Tile, IPreMoveCollisionComponent
    {
        public TileCollision(IComponentOwner owner, int xTilePosition, int yTilePosition) : base(owner, xTilePosition, yTilePosition)
        {
        }
        public bool Collide(int xTilePosition, int yTilePosition)
        {
            return xTilePosition == XTilePosition && yTilePosition == YTilePosition;
        }
    }
}
