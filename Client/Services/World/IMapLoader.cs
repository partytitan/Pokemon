using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.World;
using MonoGame.Extended.Tiled;
using MyContentPipeline.Data;

namespace Client.Services.World
{
    internal interface IMapLoader
    {
        void LoadMap(WarpData warpData, IWorldData worldData);
        WorldObject BackgroundMapLayers(IWorldData worldData);
        WorldObject ForeGoundMapLayers(IWorldData worldData);
        WorldObject LoadCollisionTiles(IWorldData worldData);
    }
}
