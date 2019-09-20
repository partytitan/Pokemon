using System;
using System.Collections.Generic;
using System.Text;
using Client.World;
using MonoGame.Extended.Tiled;

namespace Client.Services.World
{
    internal interface ITileLoader
    {
        TiledMap LoadGraphicTiles(string mapName);
        IList<ICollisionObject> LoadCollisionTiles(TiledMap map);
    }
}
