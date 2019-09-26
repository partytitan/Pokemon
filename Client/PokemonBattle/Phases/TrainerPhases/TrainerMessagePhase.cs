using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.PokemonBattle.TrainerSprites;
using Client.PokemonBattle.UI;
using Client.Screens;
using Client.Services.Content;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases.TrainerPhases
{
    class TrainerMessagePhase : IPhase
    {
        private readonly List<TrainerSprite> trainerSprites;
        private readonly List<TrainerPokemonStatus> trainerPokemonStatuses;
        private IWindowQueuer windowQueuer;
        public bool IsDone { get; set; }

        public TrainerMessagePhase(List<TrainerSprite> trainerSprites, List<TrainerPokemonStatus> trainerPokemonStatuses)
        {
            this.trainerSprites = trainerSprites;
            this.trainerPokemonStatuses = trainerPokemonStatuses;
        }

        public void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData)
        {
            this.windowQueuer = windowQueuer;
            windowQueuer.QueueWindow(new WindowBattleMessage($"{battleData.OpponentSide.Name} would like to battle! {Environment.NewLine}{Environment.NewLine} {battleData.OpponentSide.Name} sent out {battleData.OpponentSide.Party[0].Nickname}!", new InputKeyboard(), ScreenBattle.Window));
        }

        public void Update(GameTime gameTime)
        {
            IsDone = !windowQueuer.WindowActive;
        }

        public IPhase GetNextPhase()
        {
            return new OpponentTrainerOutPhase(trainerSprites, trainerPokemonStatuses);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            trainerSprites.ForEach(t => t.Draw(spriteBatch));
            trainerPokemonStatuses.ForEach(t => t.Draw(spriteBatch));
        }
    }
}
