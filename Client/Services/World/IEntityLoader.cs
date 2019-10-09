using Client.World;
using GameLogic.Data;
using System.Collections.Generic;
using Client.Services.World.EventSwitches;

namespace Client.Services.World
{
    internal interface IEntityLoader
    {
        IList<WorldObject> LoadEntities(IWorldData worldData, EventRunner eventRunner, EventSwitchHandler eventSwitchHandler, MainPlayer mainPlayer);
    }
}