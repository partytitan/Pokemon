using System.Collections.Generic;
using System.Linq;
using Client.Inputs;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;
using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases.Shared
{
    internal abstract class TrainerOutPhase<TTrainerSprite, TTrainerStatusSprite> : IPhase where TTrainerSprite : TrainerSprite where TTrainerStatusSprite : TrainerPokemonStatus
    {
        protected readonly List<TrainerSprite> TrainerSprites;
        protected readonly List<TrainerPokemonStatus> TrainerPokemonStatuses;
        public bool IsDone { get; protected set; }


        protected TrainerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.TrainerSprites = trainerSprites;
            this.TrainerPokemonStatuses = trainerPokemonStatuses;
        }

        public virtual void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData, Input input)
        {
            foreach (var trainerSprite in TrainerSprites.Where(t => t is TTrainerSprite))
            {
                trainerSprite.StartMoveOut();
            }
            foreach (var trainerPokemonStatus in TrainerPokemonStatuses.Where(t => t is TTrainerStatusSprite))
            {
                trainerPokemonStatus.StartMoveOut();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            TrainerSprites.ForEach(t => t.Update(gameTime));
            TrainerPokemonStatuses.ForEach(t => t.Update(gameTime));
            IsDone = TrainerSprites.TrueForAll(t => t.IsDone);
        }

        public abstract IPhase GetNextPhase();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            TrainerSprites.ForEach(t => t.Draw(spriteBatch));
            TrainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
