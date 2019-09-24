using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.World;
using GameLogic.Data;
using MonoGame.Extended.Tiled;

namespace Client.Services.World
{
    internal interface IMapLoader
    {
        TiledMap CurrentMap { get; set; }
        TiledMap MapUp { get; set; }
        TiledMap MapDown { get; set; }
        TiledMap MapLeft { get; set; }
        TiledMap MapRight { get; set; }
        void LoadMap(WarpData warpData, IWorldData worldData);
        WorldObject BackgroundMapLayers(IWorldData worldData);
        WorldObject ForeGoundMapLayers(IWorldData worldData);
        WorldObject LoadCollisionTiles(IWorldData worldData);
        List<WorldObject> LoadNpcs(IWorldData worldData);
    }
}
