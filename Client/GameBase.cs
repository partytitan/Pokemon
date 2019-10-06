using System.Collections.Generic;
using Client.Inputs;
using Client.PokemonBattle.Phases;
using Client.PokemonBattle.Phases.TrainerPhases;
using Client.Screens;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using Client.Services.World;
using Client.World;
using Client.World.Components;
using GameLogic.Battles;
using GameLogic.Common;
using GameLogic.Data;
using GameLogic.Moves.Reflexive;
using GameLogic.Moves.Transitive.Attack.OneTurnOneHit;
using GameLogic.Moves.Transitive.Status;
using GameLogic.PokemonData;
using GameLogic.Trainers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;

namespace Client
{
    public class GameBase : Game
    {
        private RenderTarget2D backBuffer;
        private GraphicsDeviceManager GraphicsDeviceManager;
        private SpriteBatch spriteBatch;
        private IContentLoader contentLoader;
        private ScreenLoader screenLoader;
        private MainPlayer mainPlayer;
        private Camera camera;
        private WindowHandler windowHandler;
        private static readonly int actualWidth = 800;
        private static readonly int actualHeight = 480;

        public static int GameWidth => actualWidth / 2;
        public static int GameHeight => actualHeight / 2;


        public GameBase()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            GraphicsDeviceManager.PreferredBackBufferHeight = actualHeight;
            GraphicsDeviceManager.PreferredBackBufferWidth = actualWidth;
            Content.RootDirectory = "Content";
            contentLoader = new ContentLoader(Content);
            windowHandler = new WindowHandler(contentLoader);
        }

        protected override void LoadContent()
        {
            //Debug
            var enemyPokemon = Pokemon.Builder.Init(4, 100)
                .Move1(new RazorLeaf())
                .Move2(new LeechSeed())
                .Move3(new BodySlam())
                .Move4(new Growth())
                .Create();

            var playerPokemon = Pokemon.Builder.Init(22, 100)
                .Move1(new RazorLeaf())
                .Move2(new LeechSeed())
                .Move3(new BodySlam())
                .Move4(new Growth())
                .Create();

            var playerPokemon2 = Pokemon.Builder.Init(12, 100)
                .Move1(new RazorLeaf())
                .Move2(new LeechSeed())
                .Move3(new BodySlam())
                .Move4(new Growth())
                .Create();

            mainPlayer = new MainPlayer("Jordi", new List<Pokemon>() { playerPokemon, playerPokemon2}, new WarpData(10, 18, 0, 0), Directions.Down);

            Side playerSide = new TrainerSide(mainPlayer);
            Side enemySide = new WildPokemonSide(enemyPokemon);
            //Debug end
            backBuffer = new RenderTarget2D(GraphicsDevice, GameWidth, GameHeight);
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, GameWidth, GameHeight);
            var cameraWorldObject = new WorldObject("camera");
            camera = new Camera(null, GraphicsDevice, viewportAdapter);
            cameraWorldObject.AddComponent(camera);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(actualWidth, actualHeight, 5),
                new ScreenTransitionEffectFadeIn(actualWidth, actualHeight, 3), contentLoader);

            //screenLoader.LoadScreen(new ScreenWorld(screenLoader, new MapLoader(contentLoader, GraphicsDevice), new EntityTestLoader(), new EventRunner(contentLoader), windowHandler, cameraWorldObject, mainPlayer));
            screenLoader.LoadScreen(new ScreenBattle(screenLoader, windowHandler, new BattleStartPhase(), new Battle(playerSide, enemySide, null,null) ));
            screenLoader.LoadContent(GraphicsDevice);
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