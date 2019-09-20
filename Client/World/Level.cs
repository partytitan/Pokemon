using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using Client.Screens;
using Client.Services.Content;
using Client.Services.World;
using Client.World.Components;
using Client.World.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Client.World
{
    class Level : IComponentOwner, IWorldObject
    {
        private readonly IEntityLoader _entityLoader;

        private readonly List<Component> _components;
        public string Id { get; }

        private TiledMap _map;
        private TiledMapRenderer _mapRenderer;
        private GraphicsDevice _graphicsDevice;
        private Camera _camera;

        public List<ICollisionObject> _collisionObjects;

        private readonly string _mapName;

        public int ZTilePosition => 2;

        public Level(string id, string mapName, GraphicsDevice graphicsDevice, Camera camera, IEntityLoader entityLoader)
        {
            Id = id;
            this._components = new List<Component>();
            this._mapName = mapName;
            this._graphicsDevice = graphicsDevice;
            this._camera = camera;
            this._entityLoader = entityLoader;
        }

        public void AddComponent(Component component)
        {
            if (component != null)
            {
                _components.Add(component);
            }
        }

        public T GetComponent<T>() where T : Component
        {
            var component = _components.FirstOrDefault(c => c.GetType() == typeof(T));
            return (T)component;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            _map = contentLoader.LoadMap(_mapName);
            _camera.SetScreenBounds(new Rectangle(0, 0, _map.WidthInPixels, _map.HeightInPixels));
            _mapRenderer = new TiledMapRenderer(_graphicsDevice, _map);

            SetCollisionObjects();

            _components.AddRange(_entityLoader.LoadEntities(this, _camera, _collisionObjects));

            foreach (var component in _components)
            {
                component.LoadContent(contentLoader);
            }
        }

        private void SetCollisionObjects()
        {
            _collisionObjects = new List<ICollisionObject>();
            foreach (var tileLayer in _map.TileLayers.Where(n => n.Name.Contains("Collision")))
            {
                foreach (var tile in tileLayer.Tiles)
                {
                    if (!tile.IsBlank)
                    {
                        _collisionObjects.Add(new TileCollision { XTilePosition = tile.X, YTilePosition = tile.Y });
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            _mapRenderer.Update(gameTime);

            var index = 0;
            while (index < _components.Count)
            {
                if (_components[index].Killed)
                {
                    _components.RemoveAt(index);
                }
                else
                {
                    _components[index].Update(gameTime);
                    index++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tileLayer in _map.TileLayers.Where(n => !n.Name.Contains("WalkBehind")))
            {
                _mapRenderer.Draw(tileLayer, _camera.GetViewMatrix());
            }

            foreach (var component in _components)
            {
                component.Draw(spriteBatch);
            }

            spriteBatch.End();
            spriteBatch.Begin();

            foreach (var tileLayer in _map.TileLayers.Where(n => n.Name.Contains("WalkBehind")))
            {
                _mapRenderer.Draw(tileLayer, _camera.GetViewMatrix());
            }
        }
    }
}
