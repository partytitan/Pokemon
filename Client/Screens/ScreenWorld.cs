using Client.Services.Content;
using Client.Services.Screens;
using Client.World;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Client.Inputs;
using Client.Services.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Client.Screens
{
    class ScreenWorld : Screen
    {
        private readonly ITileLoader tileLoader;
        private readonly IEntityLoader entityLoader;
        private List<IWorldObject> worldObjects;

        private TiledMap map;
        private TiledMapRenderer mapRenderer;

        public ScreenWorld(IScreenLoader screenLoader, ITileLoader tileLoader, IEntityLoader entityLoader) : base(screenLoader)
        {
            this.tileLoader = tileLoader;
            this.entityLoader = entityLoader;
        }

        public override void LoadContent(IContentLoader contentLoader, GraphicsDevice graphicsDevice)
        {
            worldObjects = new List<IWorldObject>();

            map = tileLoader.LoadGraphicTiles("0.0");

            mapRenderer = new TiledMapRenderer(graphicsDevice, map);

            worldObjects.AddRange(entityLoader.LoadEntities(""));
            foreach (var worldObject in worldObjects)
            {
                worldObject.LoadContent(contentLoader);
            }
        }

        public override void Update(GameTime gameTime, OrthographicCamera camera)
        {
            mapRenderer.Update(gameTime);
            foreach (var worldObject in worldObjects)
            {
                worldObject.Update(gameTime, camera);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, OrthographicCamera camera)
        {

            // map Should be the `TiledMap`
            // Once again, the transform matrix is only needed if you have a Camera2D
            mapRenderer.Draw(camera.GetViewMatrix());


            foreach (var worldObject in worldObjects)
            {
                worldObject.Draw(spriteBatch);
            }
        }
    }
}
