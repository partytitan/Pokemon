using Client.Screens;
using Client.Screens.ScreenTransitionEffects;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Client.Services.Screens
{
    internal class ScreenLoader : IScreenLoader
    {
        private Screen previousScreen;
        private Screen currentScreen;
        private Screen tempScreen;
        private readonly IScreenTransitionEffect previousScreenTransitionEffect;
        private readonly IScreenTransitionEffect newScreenTransitionEffect;
        private readonly IContentLoader contentLoader;

        private enum Phases { ClosingPreviousScreen, SettingUpNewScreen, Running }

        private Phases currentPhase;

        private GraphicsDevice graphicsDevice;

        public ScreenLoader(IScreenTransitionEffect previousScreenTransitionEffect,
            IScreenTransitionEffect newScreenTransitionEffect, IContentLoader contentLoader)
        {
            this.previousScreenTransitionEffect = previousScreenTransitionEffect;
            this.newScreenTransitionEffect = newScreenTransitionEffect;
            this.contentLoader = contentLoader;
            currentPhase = Phases.Running;
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
            previousScreenTransitionEffect.LoadContent(contentLoader);
            newScreenTransitionEffect.LoadContent(contentLoader);
        }

        public void Update(GameTime gameTime)
        {
            switch (currentPhase)
            {
                case Phases.ClosingPreviousScreen:
                    previousScreenTransitionEffect.Update(gameTime);
                    if (previousScreenTransitionEffect.IsDone)
                    {
                        PrepareNewScreen();
                    }
                    break;

                case Phases.SettingUpNewScreen:
                    newScreenTransitionEffect.Update(gameTime);
                    if (newScreenTransitionEffect.IsDone)
                    {
                        currentPhase = Phases.Running;
                    }
                    break;

                case Phases.Running:
                    currentScreen?.Update(gameTime);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void LoadScreen(Screen screen)
        {
            currentPhase = Phases.ClosingPreviousScreen;
            previousScreenTransitionEffect.Start();
            tempScreen = screen;
        }

        public void PrepareNewScreen()
        {
            previousScreen = currentScreen;
            currentScreen = tempScreen;
            currentScreen.LoadContent(contentLoader);
            newScreenTransitionEffect.Start();
            currentPhase = Phases.SettingUpNewScreen;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen?.Draw(spriteBatch);
            previousScreenTransitionEffect.Draw(spriteBatch);
            newScreenTransitionEffect.Draw(spriteBatch);
        }
    }
}