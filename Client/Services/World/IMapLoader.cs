using Client.World;
using GameLogic.Data;
using MonoGame.Extended.Tiled;
using System.Collections.Generic;
using Client.Services.Windows;

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

        List<WorldObject> LoadNpcs(IWorldData worldData, IEventRunner eventRunner, IWindowQueuer windowQueuer);
    }
}