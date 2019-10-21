using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.PokemonBattle.Common;
using Client.PokemonBattle.Common.PokeballEnterAnimations;
using Client.PokemonBattle.PokemonSprites;
using Client.PokemonBattle.PokemonSprites.PokemonEnterBattleAnimations;
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
        private PokemonBattleSprite playerPokemonBattleSprite;
        private PokemonBattleSprite opponentPokemonBattleSprite;
        private BattlePokemon currentPokemon;
        private BattlePokemon opponentPokemon;

        private PokemonStateBar playerPokemonStateBar;
        private PokemonStateBar opponentPokemonStateBar;

        public bool IsDone { get; }

        //FOR HEALTHBAR TEST
        private double counter;
        private Random rnd = new Random();
        private PokeballSprite opponentPokeballSprite;
        private IContentLoader contentLoader;
        private PokeballSprite playerPokeballSprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public PlayerPickAttackPhase(PokemonBattleSprite playerPokemonBattleSprite, PokemonBattleSprite opponentPokemonBattleSprite)
        {
            this.playerPokemonBattleSprite = playerPokemonBattleSprite;
            this.opponentPokemonBattleSprite = opponentPokemonBattleSprite;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData, Input input)
        {
            this.contentLoader = contentLoader;
            currentPokemon = battleData.PlayerSide.CurrentBattlePokemon;
            opponentPokemon = battleData.OpponentSide.CurrentBattlePokemon;

            playerPokemonStateBar = new PlayerPokemonStateBar(currentPokemon);
            playerPokemonStateBar.LoadContent(contentLoader);

            opponentPokemonStateBar = new TrainerPokemonStateBar(opponentPokemon);
            opponentPokemonStateBar.LoadContent(contentLoader);

            battleData.PlayerSide.CurrentBattlePokemon.SwitchedOut += BattleDataOnFirstPokemonSwitch;
            battleData.OpponentSide.CurrentBattlePokemon.SwitchedOut += BattleDataOnSecondPokemonSwitch;
            battleData.Start();
        }

        private void BattleDataOnFirstPokemonSwitch(object sender, SwitchedOutEventArgs switchedOutEventArgs)
        {
            this.playerPokemonBattleSprite = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(ScreenBattle.ArenaSize.Width * 0.25f, ScreenBattle.ArenaSize.Height * 0.95f), Color.White, $"{switchedOutEventArgs.switchIn.Number:000}-0", PokemonBattleSpriteData.PokemonFacings.Back));
            this.playerPokeballSprite = new PokeballSprite(new PokeballData(new Vector2(ScreenBattle.ArenaSize.Width * 0.25f, ScreenBattle.ArenaSize.Height * 0.95f), "Battle/Pokeballs/pokeball_regular"), new NoPokeballEnterAnimation(), new GrowPokemonEnterBattleAnimation(playerPokemonBattleSprite.GetPokemonBattleSpriteData()));
            
            playerPokemonBattleSprite.LoadContent(contentLoader);
            playerPokeballSprite.LoadContent(contentLoader);
        }

        private void BattleDataOnSecondPokemonSwitch(object sender, SwitchedOutEventArgs switchedOutEventArgs)
        {
            this.opponentPokemonBattleSprite = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(ScreenBattle.ArenaSize.Width * 0.75f, ScreenBattle.ArenaSize.Height * 0.5f), Color.White, $"{switchedOutEventArgs.switchIn.Number:000}-2", PokemonBattleSpriteData.PokemonFacings.Front));
            this.opponentPokeballSprite = new PokeballSprite(new PokeballData(new Vector2(ScreenBattle.ArenaSize.Width * 0.75f, ScreenBattle.ArenaSize.Height * 0.5f), "Battle/Pokeballs/pokeball_regular"), new NoPokeballEnterAnimation(), new TransparentPokemonEnterBattleAnimation(opponentPokemonBattleSprite.GetPokemonBattleSpriteData()));
            
            opponentPokemonBattleSprite.LoadContent(contentLoader);
            opponentPokeballSprite.LoadContent(contentLoader);
        }

        public void Update(GameTime gameTime)
        {
            
            playerPokemonStateBar.Update(gameTime);
            opponentPokemonStateBar.Update(gameTime);

            playerPokeballSprite?.Update(gameTime);
            opponentPokeballSprite?.Update(gameTime);

            //HEALTHBAR TEST
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > 1000)
            {
                playerPokemonStateBar.HealthBar.UpdateHealth(currentPokemon.HP, currentPokemon.MaxHP);
                opponentPokemonStateBar.HealthBar.UpdateHealth(opponentPokemon.HP, opponentPokemon.MaxHP);
                counter = 0;
            }
        }

        public IPhase GetNextPhase()
        {
            return null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerPokeballSprite?.Draw(spriteBatch);
            opponentPokeballSprite?.Draw(spriteBatch);
            playerPokemonBattleSprite.Draw(spriteBatch);
            opponentPokemonBattleSprite.Draw(spriteBatch);
            playerPokemonStateBar.Draw(spriteBatch);
            opponentPokemonStateBar.Draw(spriteBatch);
        }
    }
}
