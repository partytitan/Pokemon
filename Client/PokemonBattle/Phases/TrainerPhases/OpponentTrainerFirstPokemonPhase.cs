using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.PokemonBattle.Common;
using Client.PokemonBattle.Common.PokeballEnterAnimations;
using Client.PokemonBattle.Phases.PlayerPhases;
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

namespace Client.PokemonBattle.Phases.TrainerPhases
{
    class OpponentTrainerFirstPokemonPhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private PokeballSprite pokeballSprite;
        private PokemonBattleSprite pokemonBattleSprite;
        public bool IsDone { get; private set; }

        public OpponentTrainerFirstPokemonPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData, Input input)
        {
            this.pokemonBattleSprite = new PokemonBattleSprite(new PokemonBattleSpriteData(0, 0, new Vector2(ScreenBattle.ArenaSize.Width * 0.75f, ScreenBattle.ArenaSize.Height * 0.5f), Color.White, $"{battleData.OpponentSide.Party[0].Number:000}-2", PokemonBattleSpriteData.PokemonFacings.Front));
            this.pokeballSprite = new PokeballSprite(new PokeballData(new Vector2(ScreenBattle.ArenaSize.Width * 0.75f, ScreenBattle.ArenaSize.Height * 0.5f), "Battle/Pokeballs/pokeball_regular"), new NoPokeballEnterAnimation(), new TransparentPokemonEnterBattleAnimation(pokemonBattleSprite.GetPokemonBattleSpriteData()));
        
            pokeballSprite.LoadContent(contentLoader);
            pokemonBattleSprite.LoadContent(contentLoader);
        }

        public void Update(GameTime gameTime)
        {
            pokeballSprite.Update(gameTime);
            IsDone = pokeballSprite.IsDone;
        }

        public IPhase GetNextPhase()
        {
            return new PlayerOutPhase(trainerSprites, trainerPokemonStatuses, pokemonBattleSprite);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pokeballSprite.Draw(spriteBatch);
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
            pokemonBattleSprite.Draw(spriteBatch);
        }
    }
}
