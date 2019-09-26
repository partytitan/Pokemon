using System;
using System.Collections.Generic;
using System.Text;
using Client.PokemonBattle.Common;
using Client.PokemonBattle.Common.PokeballEnterAnimations;
using Client.PokemonBattle.PokemonSprites;
using Client.PokemonBattle.PokemonSprites.PokemonEnterBattleAnimations;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;
using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using GameLogic.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases.TrainerPhases
{
    class OpponentTrainerFirstPokemonPhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private readonly PokeballSprite pokeballSprite;
        private readonly PokemonBattleSprite pokemonBattleSpriteTest;
        public bool IsDone { get; private set; }

        public OpponentTrainerFirstPokemonPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
            this.pokemonBattleSpriteTest = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(165, 55), Color.White, "Pokemons/weedle_front", PokemonBattleSpriteData.PokemonFacings.Front));
            pokeballSprite = new PokeballSprite(new PokeballData(new Vector2(165, 55), "Battle/Pokeballs/pokeball_regular"), new NoPokeballEnterAnimation(), new TransparentPokemonEnterBattleAnimation(pokemonBattleSpriteTest.GetPokemonBattleSpriteData()));
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData)
        {
            pokeballSprite.LoadContent(contentLoader);
            pokemonBattleSpriteTest.LoadContent(contentLoader);
        }

        public void Update(GameTime gameTime)
        {
            pokeballSprite.Update(gameTime);
            //IsDone = pokeballSprite.IsDone;
        }

        public IPhase GetNextPhase()
        {
            return null;
            //return new PlayerTrainerOutPhase(trainerSprites, trainerPokemonStatuses, pokemonBattleSpriteTest);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pokeballSprite.Draw(spriteBatch);
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
            pokemonBattleSpriteTest.Draw(spriteBatch);
        }
    }
}
