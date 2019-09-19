using Autofac;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Client.Services.Screens;
using Client.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Client
{
    public class GameBase : Game
    {
        GraphicsDeviceManager GraphicsDeviceManager;
        SpriteBatch spriteBatch;
        Entity entity;
        IContentLoader contentLoader;
        ScreenLoader screenLoader;

        public GameBase(int width = 800, int height = 480)
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            GraphicsDeviceManager.PreferredBackBufferWidth = 240;
            GraphicsDeviceManager.PreferredBackBufferHeight = 160;
            Content.RootDirectory = "Content";
            contentLoader = new ContentLoader(Content);
            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 5),
                new ScreenTransitionEffectFadeIn(GraphicsDeviceManager.PreferredBackBufferWidth, GraphicsDeviceManager.PreferredBackBufferHeight, 3), contentLoader);
            screenLoader.LoadScreen(new ScreenWorld(screenLoader));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            backBuffer = new RenderTarget2D(GraphicsDevice, 240, 160);
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screenLoader.LoadContent();

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            screenLoader.Update(gameTime.ElapsedGameTime.Milliseconds);
            base.Update(gameTime);
        }

        protected override bool BeginDraw()
        {
            GraphicsDevice.SetRenderTarget(backBuffer);
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            screenLoader.Draw(spriteBatch);
            spriteBatch.End();

            return base.BeginDraw();
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(backBuffer, new Rectangle(0, 0, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
