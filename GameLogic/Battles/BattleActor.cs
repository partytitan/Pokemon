using System.Threading.Tasks;
using GameLogic.Moves;

namespace GameLogic.Battles
{
    public interface BattleActor
    {
        Task<Selection> MakeBeginningOfTurnSelection(Battle battle, Side actorSide);

        Task<Selection> MakeForcedSwitchSelection(Battle battle, Side actorSide);

        Task<Move> PickMoveToMimic(Side opponentSide);
    }
}