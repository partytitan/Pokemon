using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Services.Content;
using Client.World;
using Client.World.Components.Tiles;
using MonoGame.Extended.Tiled;

namespace Client.Services.World
{
    internal class TileTestLoader : ITileLoader
    {
        private readonly IContentLoader Content;
        private readonly List<ICollisionObject> collisionObjects;

        public TileTestLoader(IContentLoader content)
        {
            Content = content;
            collisionObjects = new List<ICollisionObject>();
        }

        public TiledMap LoadGraphicTiles(string mapName)
        {
            return Content.LoadMap(mapName);
        }

        public IList<ICollisionObject> LoadCollisionTiles(TiledMap map)
        {
            foreach (var tileLayer in map.TileLayers.Where(n => n.Name.Contains("Collision")))
            {
                foreach (var tile in tileLayer.Tiles)
                {
                    if (!tile.IsBlank)
                    {
                        collisionObjects.Add(new TileCollision { XTilePosition = tile.X, YTilePosition = tile.Y });
                    }
                }
            }

            return collisionObjects;
        }
    }
}
