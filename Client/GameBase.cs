using Autofac;
using Client.Data;
using Client.Inputs;
using Client.Screens;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using Client.Services.World;
using Client.World;
using Client.World.Components;
using GameLogic.Data;
using GameLogic.Trainers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.ViewportAdapters;

namespace Client
{
    public class GameBase : Game
    {
        RenderTarget2D backBuffer;
        GraphicsDeviceManager GraphicsDeviceManager;
        SpriteBatch spriteBatch;
        IContentLoader contentLoader;
        ScreenLoader screenLoader;
        Trainer trainer;
        Camera camera;
        WindowHandler windowHandler;
        private int width;
        private int height;

        public GameBase(int width = 800, int height = 480)
        {
            this.width = width;
            this.height = height;
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            GraphicsDeviceManager.PreferredBackBufferHeight = height;
            GraphicsDeviceManager.PreferredBackBufferWidth = width;
            Content.RootDirectory = "Content";
            contentLoader = new ContentLoader(Content);
            windowHandler = new WindowHandler(contentLoader);
        }

        protected override void LoadContent()
        {
            backBuffer = new RenderTarget2D(GraphicsDevice, this.width / 2, this.height / 2);
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, this.width/2, this.height/2);
            var cameraWorldObject = new WorldObject("camera");
            camera = new Camera(null,GraphicsDevice, viewportAdapter);
            cameraWorldObject.AddComponent(camera);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(this.width, this.height, 5),
                new ScreenTransitionEffectFadeIn(this.width, this.height, 3), contentLoader);
            //screenLoader.LoadScreen(new ScreenWorld(screenLoader, new MapLoader(contentLoader, GraphicsDevice), new EntityTestLoader(), new EventRunner(contentLoader), cameraWorldObject, new WarpData(16, 20, -32, -31)));
            screenLoader.LoadScreen(new ScreenWorld(screenLoader, new MapLoader(contentLoader, GraphicsDevice), new EntityTestLoader(), new EventRunner(contentLoader), cameraWorldObject, new WarpData(10,18,0,0)));
            screenLoader.LoadContent(GraphicsDevice);

            windowHandler.QueueWindow(new WindowMessage(new Vector2(25, 180), 350, 50, "Hey, Im Ash and youre going down! Hey, Im Ash and youre going down! " +
                                                                                      "Hey, Im Ash and youre going down! Hey, Im Ash and youre going down! " +
                                                                                      "Hey, Im Ash and youre going down! Hey, Im Ash and youre going down! " +
                                                                                      "Hey, Im Ash and youre going down! Hey, Im Ash and youre going down!",
                new InputKeyboard()));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            screenLoader.Update(gameTime);
            windowHandler.Update(gameTime);
            base.Update(gameTime);
        }

        protected override bool BeginDraw()
        {
            GraphicsDevice.SetRenderTarget(backBuffer);
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            windowHandler.Draw(spriteBatch);
            spriteBatch.End();
            return base.BeginDraw();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
            screenLoader.Draw(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin();
            spriteBatch.Draw(backBuffer, destinationRectangle: new Rectangle(0, 0, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
