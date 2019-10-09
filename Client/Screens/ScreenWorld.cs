using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.World;
using Client.World;
using Client.World.Interfaces;
using GameLogic.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Client.Services.Windows;
using Client.Services.World.EventSwitches;

namespace Client.Screens
{
    internal class ScreenWorld : Screen, IWorldData
    {
        public IMapLoader MapLoader { get; set; }
        private readonly IEntityLoader entityLoader;
        private readonly EventRunner eventRunner;
        private readonly IWindowQueuer windowQueuer;
        private readonly List<WorldObject> worldObjects;
        private readonly WorldObject camera;
        private readonly EventSwitchHandler eventSwitchHandler;
        public MainPlayer MainPlayer { get; set; }

        public ScreenWorld(IScreenLoader screenLoader, IMapLoader mapLoader, IEntityLoader entityLoader, EventRunner eventRunner, IWindowQueuer windowQueuer, EventSwitchHandler eventSwitch, WorldObject camera, MainPlayer mainPlayer) : base(screenLoader)
        {
            this.MapLoader = mapLoader;
            this.entityLoader = entityLoader;
            this.eventRunner = eventRunner;
            this.windowQueuer = windowQueuer;
            this.MainPlayer = mainPlayer;
            this.camera = camera;
            this.eventSwitchHandler = eventSwitch;

            worldObjects = new List<WorldObject>();
        }

        public void ChangeMap(WarpData warpData)
        {
            MainPlayer.WarpData = warpData;
            var screen = new ScreenWorld(ScreenLoader, MapLoader, entityLoader, eventRunner, windowQueuer, eventSwitchHandler, camera, MainPlayer);
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
            MapLoader.LoadMap(MainPlayer.WarpData, this);
            worldObjects.Add(MapLoader.BackgroundMapLayers(this));
            worldObjects.Add(MapLoader.LoadCollisionTiles(this));
            worldObjects.AddRange(MapLoader.LoadNpcs(this, eventRunner, windowQueuer));
            worldObjects.AddRange(entityLoader.LoadEntities(this, eventRunner, eventSwitchHandler, MainPlayer));
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
            eventRunner.Draw(spriteBatch);
            GetComponents<IDrawComponent>().ForEach(c => c.Draw(spriteBatch));
        }
    }
}