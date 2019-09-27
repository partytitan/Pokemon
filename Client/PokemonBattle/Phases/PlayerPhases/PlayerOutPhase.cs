using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.PokemonBattle.Phases.Shared;
using Client.PokemonBattle.Phases.TrainerPhases;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;
using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases.PlayerPhases
{
    class PlayerOutPhase : TrainerOutPhase<TrainerPlayerSprite, TrainerPlayerPokemonStatus>
    {
        private readonly List<TrainerSprite> TrainerSprites;
        private readonly List<TrainerPokemonStatus> TrainerPokemonStatuses;

        public PlayerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses) : base(trainerSprites, trainerPokemonStatuses)
        {
            this.TrainerSprites = trainerSprites;
            this.TrainerPokemonStatuses = trainerPokemonStatuses;
        }

        public override IPhase GetNextPhase()
        {
            var playerTrainerSprites = TrainerSprites.Where(t => t is TrainerPlayerSprite).ToList();
            foreach (var playerTrainerSprite in playerTrainerSprites)
            {
                TrainerSprites.Remove(playerTrainerSprite);
            }

            return null;
            // return new OpponentTrainerFirstPokemonPhase(TrainerSprites, TrainerPokemonStatuses);
        }
    }
}
