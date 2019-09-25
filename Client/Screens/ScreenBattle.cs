using System;
using System.Collections.Generic;
using System.Text;
using Client.PokemonBattle.Phases;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Screens
{
    internal class ScreenBattle : Screen
    {
        private IContentLoader contentLoader;
        private readonly IWindowQueuer windowQueuer;
        private IPhase currentPhase;
        private readonly Battle battleData;
        private readonly WindowBattle windowBattle;
        private Texture2D backgroundTexture;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenBattle(IScreenLoader screenLoader, IWindowQueuer windowQueuer, IPhase startPhase,
            Battle battleData) : base(screenLoader)
        {
            this.windowQueuer = windowQueuer;
            this.battleData = battleData;
            currentPhase = startPhase;
            windowBattle = new WindowBattle(new Vector2(0, GameBase.Height/2 - 60), GameBase.Width/2, 60);
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            backgroundTexture = contentLoader.LoadTexture("Battle/Backgrounds/background");
            windowBattle.LoadContent(contentLoader);
            currentPhase.LoadContent(contentLoader, windowQueuer, battleData);
            this.contentLoader = contentLoader;
        }

        public override void Update(GameTime gameTime)
        {
            currentPhase.Update(gameTime);
            //if (currentPhase.IsDone)
            //{
            //    currentPhase = currentPhase.GetNextPhase();
            //    currentPhase.LoadContent(contentLoader, windowQueuer, battleData);
            //}
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0,0,GameBase.Width/2, GameBase.Height/2 - 60), Color.White);
            currentPhase.Draw(spriteBatch);
            windowBattle.Draw(spriteBatch);
        }
    }
}
