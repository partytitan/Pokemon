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
using GameLogic.Data;
using GameLogic.Trainers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Client.Screens
{
    class ScreenWorld : Screen, IWorldData
    {
        public IMapLoader MapLoader { get; set; }
        private readonly IEntityLoader entityLoader;
        private readonly EventRunner eventRunner;
        private readonly List<WorldObject> worldObjects;
        private readonly WorldObject camera;
        public WarpData WarpData { get; set; }

        public ScreenWorld(IScreenLoader screenLoader, IMapLoader mapLoader, IEntityLoader entityLoader, EventRunner eventRunner, WorldObject camera, WarpData warpData) : base(screenLoader)
        {
            this.MapLoader = mapLoader;
            this.entityLoader = entityLoader;
            this.eventRunner = eventRunner;
            this.WarpData = warpData;
            this.camera = camera;
            
            worldObjects = new List<WorldObject>();
        }

        public void ChangeMap(WarpData warpData)
        {
            var screen = new ScreenWorld(ScreenLoader, MapLoader, entityLoader, eventRunner, camera, warpData);
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
            MapLoader.LoadMap(WarpData, this);
            worldObjects.Add(MapLoader.BackgroundMapLayers(this));
            worldObjects.Add(MapLoader.LoadCollisionTiles(this));
            worldObjects.AddRange(entityLoader.LoadEntities(this, WarpData));
            worldObjects.Add(MapLoader.ForeGoundMapLayers(this));
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
