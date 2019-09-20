using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Client.World;

namespace Client.Services.World
{
    internal interface IEntityLoader
    {
        IList<Entity> LoadEntities(IComponentOwner owner, Camera camera, IList<ICollisionObject> collisionObjects);
    }
}
