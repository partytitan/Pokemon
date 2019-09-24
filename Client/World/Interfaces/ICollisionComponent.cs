namespace Client.World.Interfaces
{
    internal interface ICollisionComponent : IComponent
    {
        bool Collide(int xTilePosition, int yTilePosition);
    }
}