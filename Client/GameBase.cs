using Autofac;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Client
{
    public abstract class GameBase : Game
    {
        private GraphicsDeviceManager GraphicsDeviceManager;
        protected IContainer Container { get; private set; }

        public int Width { get; }
        public int Height { get; }

        public GameBase(int width = 800, int height = 480)
        {
            Width = width;
            Height = height;
            GraphicsDeviceManager = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = width,
                PreferredBackBufferHeight = height
            };
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            RegisterDependencies(containerBuilder);
            Container = containerBuilder.Build();

            base.Initialize();
        }

        protected abstract void RegisterDependencies(ContainerBuilder builder);
    }
}
