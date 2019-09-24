namespace GameLogic.Battles
{
    public enum BattleState
    {
        Intro,
        SetSelections,
        SetFirstAndSecond,
        FirstExecutes,
        SecondExecutes,
        FirstFaintsEarly,
        FirstFaintsEarlySwitch,
        BothFaint,
        SecondFaints,
        FirstFaintsLate,
        FirstFaintsLateSwitch,
        SecondSwitchesPokemon,
        BothPokemonSwitch,
        GameOver
    }
}