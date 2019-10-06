using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.PokemonBattle.PokemonSprites;
using Client.PokemonBattle.UI;
using Client.Screens;
using Client.Services.Content;
using Client.Services.Windows;
using Client.Services.Windows.Battle;
using GameLogic.Battles;
using GameLogic.PokemonData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Client.PokemonBattle.Phases.PlayerPhases
{
    class PlayerPickAttackPhase : IPhase
    {
        private readonly PokemonBattleSprite playerPokemonBattleSprite;
        private readonly PokemonBattleSprite opponentPokemonBattleSprite;
        private BattlePokemon currentPokemon;
        private PokemonStateBar playerPokemonStateBar;
        public bool IsDone { get; }

        //FOR HEALTHBAR TEST
        private double counter;
        private Random rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public PlayerPickAttackPhase(PokemonBattleSprite playerPokemonBattleSprite, PokemonBattleSprite opponentPokemonBattleSprite)
        {
            this.playerPokemonBattleSprite = playerPokemonBattleSprite;
            this.opponentPokemonBattleSprite = opponentPokemonBattleSprite;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData)
        {
            currentPokemon = battleData.PlayerSide.CurrentBattlePokemon;
            playerPokemonStateBar = new PlayerPokemonStateBar(currentPokemon); //temporary
            playerPokemonStateBar.LoadContent(contentLoader);

            windowQueuer.QueueWindow(new MainBattleWindow(new Vector2(200, ScreenBattle.Window.Y), 200, ScreenBattle.WindowSize.Height, new InputKeyboard()));
        }

        public void Update(GameTime gameTime)
        {
            playerPokemonStateBar.Update(gameTime);

            //HEALTHBAR TEST
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > 1000)
            {
                playerPokemonStateBar.HealthBar.UpdateHealth((float)rnd.NextDouble() * (currentPokemon.MaxHP - 0) + 0, currentPokemon.MaxHP);
                counter = 0;
            }
        }

        public IPhase GetNextPhase()
        {
            return null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerPokemonBattleSprite.Draw(spriteBatch);
            opponentPokemonBattleSprite.Draw(spriteBatch);
            playerPokemonStateBar.Draw(spriteBatch);
        }
    }
}
