using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.Screens;
using Client.Services.Screens;
using Client.World;
using Client.World.Interfaces;
using GameLogic.Data;
using GameLogic.Trainers;

namespace Client.Services.World
{
    interface IWorldData
    {
        IMapLoader MapLoader { get; set; }
        WarpData WarpData { get; set; }
        void ChangeMap(WarpData warpData);
        WorldObject GetWorldObject(string id);
        List<T> GetComponents<T>() where T : IComponent;
    }
}
