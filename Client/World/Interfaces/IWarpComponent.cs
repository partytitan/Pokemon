namespace Client.World.Interfaces
{
    interface IWarpComponent : IComponent
    {
        void Warp(int xTilePosition, int yTilePosition, int xWarpPosition, int yWarpPosition, int xWarpMap, int yWarpMap);
    }
}
