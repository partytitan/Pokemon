using Client.World;
using Client.World.Interfaces;
using GameLogic.Data;
using System.Collections.Generic;

namespace Client.Services.World
{
    internal interface IWorldData
    {
        IMapLoader MapLoader { get; set; }
        MainPlayer MainPlayer { get; set; }

        void ChangeMap(WarpData warpData);

        WorldObject GetWorldObject(string id);

        List<T> GetComponents<T>() where T : IComponent;
    }
}