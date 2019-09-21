using Client.Screens;
using Client.Services.Content;
using Client.Services.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System.Collections.Generic;
using System.Linq;
using Client.World.Components.Tiles;

namespace Client.World
{
    internal class Level : IComponentOwner, IWorldObject
    {
        private readonly Camera camera;
        private readonly List<Component> components;
        private readonly IEntityLoader entityLoader;
        private readonly GraphicsDevice graphicsDevice;
        private readonly string mapName;
        private List<ICollisionObject> collisionObjects;
        private TiledMap map;
        private TiledMapRenderer mapRenderer;

        public Level(string id, string mapName, GraphicsDevice graphicsDevice, Camera camera, IEntityLoader entityLoader)
        {
            Id = id;
            this.components = new List<Component>();
            this.mapName = mapName;
            this.graphicsDevice = graphicsDevice;
            this.camera = camera;
            this.entityLoader = entityLoader;
        }

        public string Id { get; }
        public int ZTilePosition => 2;
        public void AddComponent(Component component)
        {
            if (component != null)
            {
                components.Add(component);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tileLayer in map.TileLayers.Where(n => !n.Name.Contains("WalkBehind")))
            {
                mapRenderer.Draw(tileLayer, camera.GetViewMatrix());
            }

            foreach (var component in components)
            {
                component.Draw(spriteBatch);
            }

            spriteBatch.End();
            spriteBatch.Begin();

            foreach (var tileLayer in map.TileLayers.Where(n => n.Name.Contains("WalkBehind")))
            {
                mapRenderer.Draw(tileLayer, camera.GetViewMatrix());
            }
        }

        public T GetComponent<T>() where T : Component
        {
            var component = components.FirstOrDefault(c => c.GetType() == typeof(T));
            return (T)component;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            map = contentLoader.LoadMap(mapName);
            camera.SetScreenBounds(new Rectangle(0, 0, map.WidthInPixels, map.HeightInPixels));
            mapRenderer = new TiledMapRenderer(graphicsDevice, map);

            SetCollisionObjects();

            components.AddRange(entityLoader.LoadEntities(this, camera, collisionObjects));

            foreach (var component in components)
            {
                component.LoadContent(contentLoader);
            }
        }

        public void Update(GameTime gameTime)
        {
            mapRenderer.Update(gameTime);

            var index = 0;
            while (index < components.Count)
            {
                if (components[index].Killed)
                {
                    components.RemoveAt(index);
                }
                else
                {
                    components[index].Update(gameTime);
                    index++;
                }
            }
        }

        private void SetCollisionObjects()
        {
            collisionObjects = new List<ICollisionObject>();
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
        }
    }
}