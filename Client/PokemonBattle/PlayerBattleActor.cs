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
        private TaskCompletionSource<Selection> selectionMade;
        private readonly InputKeyboard input;

        private readonly IWindowQueuer windowQueuer;

        public PlayerBattleActor(IWindowQueuer windowQueuer)
        {
            this.windowQueuer = windowQueuer;
            this.input = new InputKeyboard();
        }

        public async Task<Selection> MakeBeginningOfTurnSelection(Battle battle, Side actorSide)
        {
            // Wait for the user to click Continue.
            selectionMade = new TaskCompletionSource<Selection>();

            windowQueuer.QueueWindow(new MainBattleWindow(ScreenBattle.Window, input, actorSide, battle, selectionMade));

            return await selectionMade.Task;
        }
        public async Task<Selection> MakeForcedSwitchSelection(Battle battle, Side actorSide)
        {
            selectionMade = new TaskCompletionSource<Selection>();

            windowQueuer.QueueWindow(new MainBattleWindow(ScreenBattle.Window, input, actorSide, battle, selectionMade, true));

            return await selectionMade.Task;
        }

        public Task<Move> PickMoveToMimic(Side opponentSide)
        {
            throw new NotImplementedException();
        }
    }
}
