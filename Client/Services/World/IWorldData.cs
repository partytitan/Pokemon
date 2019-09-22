using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.Screens;
using Client.Services.Screens;
using Client.World;
using MyContentPipeline.Data;

namespace Client.Services.World
{
    interface IWorldData
    {
        void ChangeMap(WarpData warpData);
        WorldObject GetWorldObject(string id);
        List<T> GetComponents<T>() where T : IComponent;
    }
}
