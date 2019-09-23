using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.Screens;
using Client.World;
using GameLogic.Data;

namespace Client.Services.World
{
    internal interface IEntityLoader
    {
        IList<WorldObject> LoadEntities(IWorldData worldData, WarpData warpData);
    }
}
