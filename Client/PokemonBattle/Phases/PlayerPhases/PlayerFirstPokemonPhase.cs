using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.PokemonBattle.Common;
using Client.PokemonBattle.Common.PokeballEnterAnimations;
using Client.PokemonBattle.PokemonSprites;
using Client.PokemonBattle.PokemonSprites.PokemonEnterBattleAnimations;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;
using Client.Screens;
using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using GameLogic.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases.PlayerPhases
{
    class PlayerFirstPokemonPhase : IPhase
    {
        private readonly PokemonBattleSprite opponentPokemonBattleSprite;
        private PokemonBattleSprite pokemonBattleSprite;
        private PokeballSprite pokeballSprite;

        public PlayerFirstPokemonPhase(List<TrainerPokemonStatus> trainerPokemonStatuses, PokemonBattleSprite opponentPokemonBattleSprite)
        {
            this.opponentPokemonBattleSprite = opponentPokemonBattleSprite;
        }

        public bool IsDone { get; set; }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData)
        {
            this.pokemonBattleSprite = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(ScreenBattle.ArenaSize.Width * 0.25f, ScreenBattle.ArenaSize.Height * 0.95f), Color.White, $"{battleData.PlayerSide.Party[0].Number:000}-0", PokemonBattleSpriteData.PokemonFacings.Back));
            this.pokeballSprite = new PokeballSprite(new PokeballData(new Vector2(ScreenBattle.ArenaSize.Width * 0.25f, ScreenBattle.ArenaSize.Height * 0.95f), "Battle/Pokeballs/pokeball_regular"), new NoPokeballEnterAnimation(), new TransparentPokemonEnterBattleAnimation(pokemonBattleSprite.GetPokemonBattleSpriteData()));

            pokeballSprite.LoadContent(contentLoader);
            pokemonBattleSprite.LoadContent(contentLoader);
        }

        public void Update(GameTime gameTime)
        {
            pokeballSprite.Update(gameTime);
            //IsDone = pokeballSprite.IsDone;
        }

        public IPhase GetNextPhase()
        {
            return null;
            //return new PickAttackPhase(pokemonBattleSprite, opponentPokemonBattleSprite);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pokeballSprite.Draw(spriteBatch);

            pokemonBattleSprite.Draw(spriteBatch);
            opponentPokemonBattleSprite.Draw(spriteBatch);
        }
    }
}
