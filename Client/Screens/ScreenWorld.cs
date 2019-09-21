using Client.Services.Content;
using Client.Services.Screens;
using Client.World;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    class ScreenWorld : Screen, IWorldData
    {
        private readonly IMapLoader mapLoader;
        private readonly IEntityLoader entityLoader;
        private readonly EventRunner eventRunner;
        private readonly List<WorldObject> worldObjects;
        private readonly WorldObject camera;
        private readonly WarpData warpData;

        public ScreenWorld(IScreenLoader screenLoader, IMapLoader mapLoader, IEntityLoader entityLoader, EventRunner eventRunner, WorldObject camera, WarpData warpData) : base(screenLoader)
        {
            this.mapLoader = mapLoader;
            this.entityLoader = entityLoader;
            this.eventRunner = eventRunner;
            this.warpData = warpData;
            this.camera = camera;
            
            worldObjects = new List<WorldObject>();
        }
        public void ChangeMap(WarpData warpData)
        {
            var screen = new ScreenWorld(ScreenLoader, mapLoader, entityLoader, eventRunner, camera, warpData);
            ScreenLoader.LoadScreen(screen);
        }
        public WorldObject GetWorldObject(string id)
        {
            return worldObjects.FirstOrDefault(w => w.Id == id);
        }

        public List<T> GetComponents<T>() where T : IComponent
        {
            var components = new List<T>();
            foreach (var worldObject in worldObjects)
            {
                components.AddRange(worldObject.GetComponents<T>());
            }
            return components;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            worldObjects.Add(camera);
            mapLoader.LoadMap(warpData, this);
            worldObjects.Add(mapLoader.BackgroundMapLayers(this));
            worldObjects.Add(mapLoader.LoadCollisionTiles(this));
            worldObjects.AddRange(entityLoader.LoadEntities(this, warpData));
            worldObjects.Add(mapLoader.ForeGoundMapLayers(this));
            GetComponents<ILoadContentComponent>().ForEach(c => c.LoadContent(contentLoader));
            eventRunner.LoadContent(this);
        }

        public override void Update(GameTime gameTime)
        {
            GetComponents<IUpdateComponent>().ForEach(c => c.Update(gameTime));
            eventRunner.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            GetComponents<IDrawComponent>().ForEach(c => c.Draw(spriteBatch));
            eventRunner.Draw(spriteBatch);
        }
    }
}
