using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Battles;
using GameLogic.Moves;

namespace Client.PokemonBattle
{
    class PlayerBattleActor : BattleActor
    {
        private TaskCompletionSource<object> selectionMade;
        Selection playersSelection = null;

        public async Task<Selection> MakeBeginningOfTurnSelection(Battle battle, Side actorSide)
        {
            await GetSelection();

            return playersSelection;
        }
        private async Task GetSelection()
        {
            // Do lot of complex stuff that takes a long time
            // (e.g. contact some web services)

            // Wait for the user to click Continue.
            selectionMade = new TaskCompletionSource<object>();
            await selectionMade.Task;

            
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
