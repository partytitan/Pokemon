using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Data;
using Client.Services.Content;
using Client.World;
using Client.World.Components;
using Client.World.Components.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MyContentPipeline.Data;

namespace Client.Services.World
{
    internal class MapLoader : IMapLoader
    {
        private readonly IContentLoader contentLoader;
        private TiledMap tiledMap;
        private MapData mapData;
        private TiledMapRenderer tiledMapRenderer;
        private readonly GraphicsDevice graphicsDevice;

        public MapLoader(IContentLoader contentLoader, GraphicsDevice graphicsDevice)
        {
            this.contentLoader = contentLoader;
            this.graphicsDevice = graphicsDevice;
        }

        public void LoadMap(WarpData warpData, IWorldData worldData)
        {
            mapData = contentLoader.LoadMapData($"{warpData.XMapId}.{warpData.YMapId}");
            tiledMap = contentLoader.LoadMap($"{warpData.XMapId}.{warpData.YMapId}");
            tiledMapRenderer = new TiledMapRenderer(graphicsDevice, tiledMap);
            var camera = worldData.GetComponents<Camera>().FirstOrDefault();
                camera?.SetScreenBounds(new Rectangle(0,0,tiledMap.WidthInPixels, tiledMap.HeightInPixels));
        }

        public WorldObject BackgroundMapLayers(IWorldData worldData)
        {
            var backgroundLayers = new WorldObject("map_background");
            foreach (var tileLayer in tiledMap.TileLayers.Where(n => !n.Name.Contains("WalkBehind")))
            { 
                backgroundLayers.AddComponent(new TileLayer(backgroundLayers, tileLayer, tiledMapRenderer, worldData));
            }

            return backgroundLayers;
        }

        public WorldObject ForeGoundMapLayers(IWorldData worldData)
        {
            var foregroundLayers = new WorldObject("map_foreground");
            foreach (var tileLayer in tiledMap.TileLayers.Where(n => n.Name.Contains("WalkBehind")))
            {
                foregroundLayers.AddComponent(new TileLayer(foregroundLayers, tileLayer, tiledMapRenderer, worldData));
            }

            return foregroundLayers;
        }

        public WorldObject LoadCollisionTiles(IWorldData worldData)
        {
            var collisionObject = new WorldObject($"tile_collisions");
            foreach (var tileLayer in tiledMap.TileLayers.Where(n => n.Name.Contains("Collision")))
            {
                foreach (var tile in tileLayer.Tiles)
                {
                    if (!tile.IsBlank)
                    {
                        collisionObject.AddComponent(new TileCollision(collisionObject, tile.X, tile.Y));
                    }
                }
            }

            foreach (var warp in mapData.WarpList)
            {
                collisionObject.AddComponent(new WarpCollision(collisionObject, warp, worldData));
            }

            return collisionObject;
        }

    }
}
