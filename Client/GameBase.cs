using Autofac;
using Client.Screens;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.World;
using Client.World;
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
        Entity entity;
        IContentLoader contentLoader;
        ScreenLoader screenLoader;

        Camera _camera;


        public GameBase(int width = 800, int height = 480)
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            contentLoader = new ContentLoader(Content);
        }

        protected override void LoadContent()
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 400, 240);
            _camera = new Camera(viewportAdapter);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 5),
                new ScreenTransitionEffectFadeIn(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 3), contentLoader);
            screenLoader.LoadScreen(new ScreenWorld(screenLoader, new TileTestLoader(contentLoader), new EntityTestLoader(), new EventRunner(contentLoader), GraphicsDevice, _camera));
            screenLoader.LoadContent(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            screenLoader.Update(gameTime, _camera);
            base.Update(gameTime);
        }

        protected override bool BeginDraw()
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
            screenLoader.Draw(spriteBatch, _camera);
            spriteBatch.End();

            return base.BeginDraw();
        }
    }
}
