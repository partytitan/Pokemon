using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Services.World;
using Client.World.Interfaces;
using Microsoft.Xna.Framework;

namespace Client.World.Components
{
    internal class Collision : Component, IPreMoveCollisionComponent
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

        public bool Collide(int xTilePosition, int yTilePosition)
        {
            var sprite = Owner.GetComponent<Sprite>();
            if (sprite == null)
                return false;
            return sprite.TilePosition == new Vector2(xTilePosition, yTilePosition);
        }
    }
}
