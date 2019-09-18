using Autofac;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using Platformer.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class GameMain : GameBase
    {
        private TiledMap _map;
        private TiledMapRenderer _renderer;

        private OrthographicCamera _camera;
        private World _world;

        public GameMain()
        {

        }

        protected override void RegisterDependencies(ContainerBuilder builder)
        {
            _camera = new OrthographicCamera(GraphicsDevice);

            builder.RegisterInstance(new SpriteBatch(GraphicsDevice));
            builder.RegisterInstance(_camera);
        }

        protected override void LoadContent()
        {
            _world = new WorldBuilder()
                .AddSystem(new WorldSystem())
                .AddSystem(new PlayerSystem())
                .AddSystem(new RenderSystem(new SpriteBatch(GraphicsDevice), _camera))
                .Build();

            Components.Add(_world);

            _entityFactory = new EntityFactory(_world, Content);

            // TOOD: Load maps and collision data more nicely :)
            _map = Content.Load<TiledMap>("test-map");
            _renderer = new TiledMapRenderer(GraphicsDevice, _map);

            foreach (var tileLayer in _map.TileLayers)
            {
                for (var x = 0; x < tileLayer.Width; x++)
                {
                    for (var y = 0; y < tileLayer.Height; y++)
                    {
                        var tile = tileLayer.GetTile((ushort)x, (ushort)y);

                        if (tile.GlobalIdentifier == 1)
                        {
                            var tileWidth = _map.TileWidth;
                            var tileHeight = _map.TileHeight;
                            _entityFactory.CreateTile(x, y, tileWidth, tileHeight);
                        }
                    }
                }
            }

            _entityFactory.CreatePlayer(new Vector2(100, 240));
        }
    }
}
