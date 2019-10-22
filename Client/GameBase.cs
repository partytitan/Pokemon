using System;
using System.Collections.Generic;
using Client.Screens;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.Windows;
using Client.Services.World;
using Client.Services.World.EventSwitches;
using Client.World;
using Client.World.Components;
using GameLogic.Common;
using GameLogic.Data;
using GameLogic.PokemonData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
            var pokemon = new List<Pokemon>();
            var rnd = new Random();
            pokemon.Add(Pokemon.GenerateWildPokemon(rnd.Next(1, 5), rnd.Next(1, 50)));
            pokemon.Add(Pokemon.GenerateWildPokemon(rnd.Next(1, 5), rnd.Next(1, 50)));
            pokemon.Add(Pokemon.GenerateWildPokemon(rnd.Next(1, 5), rnd.Next(1, 50)));
            pokemon.Add(Pokemon.GenerateWildPokemon(rnd.Next(1, 5), rnd.Next(1, 50)));

            mainPlayer = new MainPlayer("Jordi", pokemon, new WarpData(19, 19, -3, -2), Directions.Down);

            backBuffer = new RenderTarget2D(GraphicsDevice, GameWidth, GameHeight);
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, GameWidth, GameHeight);

            var eventSwitchHandler = new EventSwitchHandler();
            eventSwitchHandler.AddEventSwitch(new EventSwitch { Id = 1, Name = "Test", On = false });

            var cameraWorldObject = new WorldObject("camera", eventSwitchHandler);
            camera = new Camera(null, GraphicsDevice, viewportAdapter);
            cameraWorldObject.AddComponent(camera);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MediaPlayer.IsRepeating = true;

            screenLoader = new ScreenLoader(new ScreenTransitionEffectFadeOut(actualWidth, actualHeight, 5),
                new ScreenTransitionEffectFadeIn(actualWidth, actualHeight, 3), contentLoader);

            var world = new ScreenWorld(screenLoader, new MapLoader(contentLoader, eventSwitchHandler, GraphicsDevice), new EntityTestLoader(), new EventRunner(contentLoader), windowHandler, eventSwitchHandler, cameraWorldObject, mainPlayer);
            screenLoader.LoadScreen(world);
            screenLoader.LoadContent(GraphicsDevice);
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