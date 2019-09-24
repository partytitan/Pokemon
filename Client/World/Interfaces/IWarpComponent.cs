namespace Client.World.Interfaces
{
    internal interface IWarpComponent : IComponent
    {
        void Warp(int xTilePosition, int yTilePosition, int xWarpPosition, int yWarpPosition, int xWarpMap, int yWarpMap);
    }
}