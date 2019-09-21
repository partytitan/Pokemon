using Autofac;
using Client.Data;
using Client.Screens;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.World;
using Client.World;
using Client.World.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ViewportAdapters;

namespace Client
{
    public class GameBase : Game
    {
        private readonly GraphicsDeviceManager GraphicsDeviceManager;
        SpriteBatch spriteBatch;
        readonly IContentLoader contentLoader;
        ScreenLoader screenLoader;

        Camera camera;


        public GameBase(int width = 800, int height = 480)
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            contentLoader = new ContentLoader(Content);
        }

        protected override void LoadContent()
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 400, 240);
            var cameraWorldObject = new WorldObject("camera");
            camera = new Camera(null,GraphicsDevice, viewportAdapter);
            cameraWorldObject.AddComponent(camera);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 5),
                new ScreenTransitionEffectFadeIn(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 3), contentLoader);
            //screenLoader.LoadScreen(new ScreenWorld(screenLoader, new MapLoader(contentLoader, GraphicsDevice), new EntityTestLoader(), new EventRunner(contentLoader), cameraWorldObject, new WarpData(16, 20, -32, -31)));
            screenLoader.LoadScreen(new ScreenWorld(screenLoader, new MapLoader(contentLoader, GraphicsDevice), new EntityTestLoader(), new EventRunner(contentLoader), cameraWorldObject, new WarpData(10,18,0,0)));
            screenLoader.LoadContent(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            screenLoader.Update(gameTime);
            base.Update(gameTime);
        }

        protected override bool BeginDraw()
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
            screenLoader.Draw(spriteBatch);
            spriteBatch.End();

            return base.BeginDraw();
        }
    }
}
