using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using MonoGame.Extended.Tiled;

namespace Client.Services.World
{
    internal class TileTestLoader : ITileLoader
    {
        private readonly IContentLoader Content;

        public TileTestLoader(IContentLoader content)
        {
            Content = content;
        }

        public TiledMap LoadGraphicTiles(string mapName)
        {
            // Load the compiled map
            return Content.LoadMap(mapName);

        }
    }
}
