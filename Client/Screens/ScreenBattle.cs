using Client.Inputs;
using Client.PokemonBattle;
using Client.PokemonBattle.Phases;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using Client.World.Components;
using Microsoft.Xna.Framework.Media;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Client.Screens
{
    internal class ScreenBattle : Screen
    {
        public static Size WindowSize = new Size(GameBase.GameWidth, GameBase.GameHeight / 4);
        public static Size ArenaSize = new Size(GameBase.GameWidth, GameBase.GameHeight - WindowSize.Height);
        public static Rectangle Window = new Rectangle(0, ArenaSize.Height, GameBase.GameWidth, GameBase.GameHeight / 4);

        public readonly Input Input;
        public readonly IWindowQueuer WindowQueuer;

        private readonly Battle battleData;
        private readonly WindowBattle windowBattle;
        private readonly ScreenWorld world;

        private Texture2D backgroundTexture;
        private IContentLoader contentLoader;
        private IPhase currentPhase;

        public ScreenBattle(IScreenLoader screenLoader, IWindowQueuer windowQueuer, IPhase startPhase,
            Battle battleData, ScreenWorld world) : base(screenLoader)
        {
            this.WindowQueuer = windowQueuer;
            this.battleData = battleData;
            this.currentPhase = startPhase;
            this.windowBattle = new WindowBattle(Window);
            this.Input = new InputKeyboard();
            this.Input.ThrottleInput = true;
            this.world = world;

            BattleEventsHandler eventsHandler = new BattleEventsHandler(this, screenLoader);
            eventsHandler.AttachMyBattlePokemonEventHandlers(battleData.PlayerSide.CurrentBattlePokemon);
            eventsHandler.AttachOpponentBattlePokemonEventHandlers(battleData.OpponentSide.CurrentBattlePokemon);
            eventsHandler.AttachBattleEventHandlers(battleData);

            battleData.BattleOver += BattleOverEventHandler;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, ArenaSize.Width, ArenaSize.Height), Color.White);
            currentPhase.Draw(spriteBatch);
            windowBattle.Draw(spriteBatch);
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            var song = contentLoader.LoadSong("18-GSBattle_PvNPC");
            MediaPlayer.Play(song);

            backgroundTexture = contentLoader.LoadTexture("Battle/Backgrounds/background");
            windowBattle.LoadContent(contentLoader);
            currentPhase.LoadContent(contentLoader, WindowQueuer, battleData, Input);
            this.contentLoader = contentLoader;

            world.camera.GetComponent<Camera>().Position = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            battleData.Update();
            currentPhase.Update(gameTime);
            if (currentPhase.IsDone)
            {
                currentPhase = currentPhase.GetNextPhase();
                currentPhase.LoadContent(contentLoader, WindowQueuer, battleData, Input);
            }
        }
        private void BattleOverEventHandler(object sender, BattleEventArgs args)
        {
            var message = new WindowBattleMessage(args.thisBattle.IsPlayerDefeated ? "You lost!" : "You won!", Input,
                ScreenBattle.Window);
            message.OnClose += (o, eventArgs) => ScreenLoader.LoadScreen(world);
            WindowQueuer.QueueWindow(message);
        }
    }
}