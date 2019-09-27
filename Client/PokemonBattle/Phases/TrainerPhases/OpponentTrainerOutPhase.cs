using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.PokemonBattle.Phases.Shared;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;

namespace Client.PokemonBattle.Phases.TrainerPhases
{
    class OpponentTrainerOutPhase : TrainerOutPhase<TrainerOpponentSprite, TrainerOpponentPokemonStatus>
    {
        public OpponentTrainerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses) : base(trainerSprites, trainerPokemonStatuses)
        {
        }

        public override IPhase GetNextPhase()
        {
            var opponentTrainerSprites = TrainerSprites.Where(t => t is TrainerOpponentSprite).ToList();
            foreach (var opponentTrainerSprite in opponentTrainerSprites)
            {
                TrainerSprites.Remove(opponentTrainerSprite);
            }

            return new OpponentTrainerFirstPokemonPhase(TrainerSprites, TrainerPokemonStatuses);
        }
    }
}
