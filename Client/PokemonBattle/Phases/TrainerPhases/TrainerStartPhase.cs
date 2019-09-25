using System;
using System.Collections.Generic;
using System.Text;
using Client.PokemonBattle.TrainerSprites;
using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases.TrainerPhases
{
    internal class TrainerStartPhase : IPhase
    {
        private List<TrainerSprite> trainerSprites;
        public bool IsDone { get; set; }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData)
        {
            trainerSprites = new List<TrainerSprite>
            {
                //new TrainerOpponentSprite($"Trainers/{battleData.OpponentSide.Name}"),
                new TrainerOpponentSprite("Trainers/Spr_DP_Barry"),
                new TrainerPlayerSprite("Trainers/mainPlayer")
            };
            trainerSprites.ForEach(t => t.LoadContent(contentLoader));
        }

        public void Update(GameTime gameTime)
        {
            trainerSprites.ForEach(t => t.Update(gameTime));
            IsDone = trainerSprites.TrueForAll(t => t.IsDone);
        }

        public IPhase GetNextPhase()
        {
            return new TrainerStatusPhase(trainerSprites);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
