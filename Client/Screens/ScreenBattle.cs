using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Client.Inputs;
using Client.PokemonBattle;
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
        public IWindowQueuer windowQueuer;
        public IPhase currentPhase;
        public Battle battleData;
        private Input input;
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
            this.currentPhase = startPhase;
            this.windowBattle = new WindowBattle(Window);
            this.input = new InputKeyboard();
            this.input.ThrottleInput = true;

            BattleEventsHandler eventsHandler = new BattleEventsHandler(this);
            eventsHandler.AttachMyBattlePokemonEventHandlers(battleData.PlayerSide.CurrentBattlePokemon);
            eventsHandler.AttachOpponentBattlePokemonEventHandlers(battleData.OpponentSide.CurrentBattlePokemon);
            eventsHandler.AttachBattleEventHandlers(battleData);
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            backgroundTexture = contentLoader.LoadTexture("Battle/Backgrounds/background");
            windowBattle.LoadContent(contentLoader);
            currentPhase.LoadContent(contentLoader, windowQueuer, battleData, input);
            this.contentLoader = contentLoader;
        }

        public override void Update(GameTime gameTime)
        {
            battleData.Update();
            currentPhase.Update(gameTime);
            if (currentPhase.IsDone)
            {
                currentPhase = currentPhase.GetNextPhase();
                currentPhase.LoadContent(contentLoader, windowQueuer, battleData, input);
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
