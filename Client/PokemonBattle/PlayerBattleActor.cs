using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Client.Inputs;
using Client.Screens;
using Client.Services.Windows;
using Client.Services.Windows.Battle;
using GameLogic.Battles;
using GameLogic.Moves;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle
{
    class PlayerBattleActor : BattleActor
    {
        private TaskCompletionSource<bool> selectionMade;
        private Selection playersSelection = null;
        private InputKeyboard input;

        private IWindowQueuer windowQueuer;

        public PlayerBattleActor(IWindowQueuer windowQueuer)
        {
            this.windowQueuer = windowQueuer;
            this.input = new InputKeyboard();
        }

        public async Task<Selection> MakeBeginningOfTurnSelection(Battle battle, Side actorSide)
        {
            windowQueuer.QueueWindow(new MainBattleWindow(ScreenBattle.Window, input, actorSide));
            // Wait for the user to click Continue.
            selectionMade = new TaskCompletionSource<bool>();
            await selectionMade.Task;
            playersSelection = Selection.MakeEmptyFight();
            return playersSelection;
        }
        public Task<Selection> MakeForcedSwitchSelection(Battle battle, Side actorSide)
        {
            throw new NotImplementedException();
        }

        public Task<Move> PickMoveToMimic(Side opponentSide)
        {
            throw new NotImplementedException();
        }
    }
}
