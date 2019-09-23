using GameLogic.Moves;

namespace GameLogic.Battles
{
    public interface BattleActor
    {
        Selection MakeBeginningOfTurnSelection(Battle battle, Side actorSide);
        Selection MakeForcedSwitchSelection(Battle battle, Side actorSide);
        Move PickMoveToMimic(Side opponentSide);
    }
}
