using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Tiled;

namespace Client.Services.World
{
    internal interface ITileLoader
    {
        TiledMap LoadGraphicTiles(string mapName);
    }
}
