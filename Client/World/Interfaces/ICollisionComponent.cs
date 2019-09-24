namespace Client.World.Interfaces
{
    interface ICollisionComponent : IComponent
    {
        bool Collide(int xTilePosition, int yTilePosition);
    }
}
