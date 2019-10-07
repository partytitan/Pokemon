using System.Collections.Generic;
using Client.Inputs;
using Client.PokemonBattle.Phases.TrainerPhases;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;
using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases
{
    class BattleStatusPhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private List<TrainerPokemonStatus> trainerPokemonStatuses;
        public bool IsDone { get; set; }

        public BattleStatusPhase(List<TrainerSprite> trainerSprites)
        {
            this.trainerSprites = trainerSprites;
        }


        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData, Input input)
        {
            trainerPokemonStatuses = new List<TrainerPokemonStatus>
            {
                new TrainerOpponentPokemonStatus(battleData.OpponentSide.Party),
                new TrainerPlayerPokemonStatus(battleData.PlayerSide.Party)
            };
            trainerPokemonStatuses.ForEach(t => t.LoadContent(contentLoader));
        }

        public void Update(GameTime gameTime)
        {
            trainerPokemonStatuses.ForEach(t => t.Update(gameTime));
            IsDone = trainerPokemonStatuses.TrueForAll(t => t.IsDone);
        }

        public IPhase GetNextPhase()
        {
            return new TrainerMessagePhase(trainerSprites, trainerPokemonStatuses);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
