using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Client.PokemonBattle.Phases;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Client.Screens
{
    internal class ScreenBattle : Screen
    {
        private IContentLoader contentLoader;
        private readonly IWindowQueuer windowQueuer;
        private IPhase currentPhase;
        public Battle battleData;
        private readonly WindowBattle windowBattle;
        private Texture2D backgroundTexture;
        public static Size WindowSize = new Size(GameBase.GameWidth, GameBase.GameHeight / 4);
        public static Size ArenaSize = new Size(GameBase.GameWidth, GameBase.GameHeight - WindowSize.Height);
        public static Rectangle Window = new Rectangle(0,ArenaSize.Height, GameBase.GameWidth, GameBase.GameHeight / 4);

        public ScreenBattle(IScreenLoader screenLoader, IWindowQueuer windowQueuer, IPhase startPhase,
            Battle battleData) : base(screenLoader)
        {
            this.windowQueuer = windowQueuer;
            this.battleData = battleData;
            currentPhase = startPhase;
            windowBattle = new WindowBattle(Window);
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
            battleData.Update();
            currentPhase.Update(gameTime);
            if (currentPhase.IsDone)
            {
                currentPhase = currentPhase.GetNextPhase();
                currentPhase.LoadContent(contentLoader, windowQueuer, battleData);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0,0, ArenaSize.Width, ArenaSize.Height), Color.White);
            currentPhase.Draw(spriteBatch);
            windowBattle.Draw(spriteBatch);
        }
    }
}
