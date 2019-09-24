using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Client.Screens;
using Client.Services.World;
using Client.World.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Client.World.Components.Tiles
{
    class TileLayer : Component, IUpdateComponent, IDrawComponent
    {
        private readonly TiledMapLayer tiledMapLayer;
        private readonly TiledMapRenderer tiledMapRenderer;
        private readonly Camera camera;

        public TileLayer(IComponentOwner owner, TiledMapLayer tiledMapLayer, TiledMapRenderer tiledMapRenderer, IWorldData worldData) : base(owner)
        {
            this.tiledMapLayer = tiledMapLayer;
            this.tiledMapRenderer = tiledMapRenderer;
            this.camera = worldData.GetComponents<Camera>().FirstOrDefault();
        }

        public void Update(GameTime gameTime)
        {
            tiledMapRenderer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Owner.Id == "map_foreground")
            {
                spriteBatch.End();
                spriteBatch.Begin();
            }
            tiledMapRenderer.Draw(tiledMapLayer, this.camera.GetViewMatrix());
        }
    }
}
