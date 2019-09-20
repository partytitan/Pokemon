using Client.Services.Content;
using Client.Services.Screens;
using Client.World;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Data;
using Client.Inputs;
using Client.Services.World;
using Client.World.Components;
using Client.World.Components.Animations;
using Client.World.Components.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Client.Screens
{
    class ScreenWorld : Screen
    {
        private readonly ITileLoader tileLoader;
        private readonly IEntityLoader entityLoader;
        private readonly IEventRunner eventRunner;
        private List<IWorldObject> worldObjects;

        private TiledMap map;
        private TiledMapRenderer mapRenderer;

        private GraphicsDevice _graphicsDevice;
        private Camera _camera;

        public ScreenWorld(IScreenLoader screenLoader, ITileLoader tileLoader, IEntityLoader entityLoader, IEventRunner eventRunner, GraphicsDevice graphicsDevice, Camera camera) : base(screenLoader)
        {
            this.tileLoader = tileLoader;
            this.entityLoader = entityLoader;
            this.eventRunner = eventRunner;
            this._graphicsDevice = graphicsDevice;
            this._camera = camera;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            worldObjects = new List<IWorldObject>();
            
            Level level = new Level("level", "0.0", _graphicsDevice, _camera, entityLoader);
            worldObjects.Add(level);

            foreach (var worldObject in worldObjects)
            {
                worldObject.LoadContent(contentLoader);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.Draw(spriteBatch);
            }
        }
    }
}
