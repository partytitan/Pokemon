using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.PokemonBattle.Phases.Shared;
using Client.PokemonBattle.Phases.TrainerPhases;
using Client.PokemonBattle.PokemonSprites;
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
        private readonly PokemonBattleSprite opponentPokemonBattleSprite;

        public PlayerOutPhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses, PokemonBattleSprite opponentPokemonBattleSprite) : base(trainerSprites, trainerPokemonStatuses)
        {
            this.TrainerSprites = trainerSprites;
            this.TrainerPokemonStatuses = trainerPokemonStatuses;
            this.opponentPokemonBattleSprite = opponentPokemonBattleSprite;
        }

        public override IPhase GetNextPhase()
        {
            var playerTrainerSprites = TrainerSprites.Where(t => t is TrainerPlayerSprite).ToList();
            foreach (var playerTrainerSprite in playerTrainerSprites)
            {
                TrainerSprites.Remove(playerTrainerSprite);
            }

            return new PlayerFirstPokemonPhase(TrainerPokemonStatuses, opponentPokemonBattleSprite);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            opponentPokemonBattleSprite.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
