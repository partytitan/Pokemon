using Client.World;
using GameLogic.Data;
using System.Collections.Generic;

namespace Client.Services.World
{
    internal interface IEntityLoader
    {
        IList<WorldObject> LoadEntities(IWorldData worldData, WarpData warpData);
    }
}