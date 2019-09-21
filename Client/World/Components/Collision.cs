using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Services.World;
using Microsoft.Xna.Framework;

namespace Client.World.Components
{
    internal class Collision : Component
    {
        private readonly IWorldData worldData;

        public Collision(IComponentOwner owner, IWorldData worldData) : base(owner)
        {
            this.worldData = worldData;
        }

        public bool CheckCollision<T>(int xTilePosition, int yTilePosition) where T : ICollisionComponent
        {
            var collisionObjects = worldData.GetComponents<T>();
            return collisionObjects.Any(c => c.Collide(xTilePosition, yTilePosition));
        }
    }
}
