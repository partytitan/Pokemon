using GameLogic.Moves;
using System;
using System.Linq;
using System.Threading.Tasks;
using GameLogic.PokemonData;

namespace GameLogic.Battles
{
    public class TrainerPokemonActor : BattleActor
    {
        Random rng = new Random();
        public async Task<Selection> MakeBeginningOfTurnSelection(Battle battle, Side actorSide)
        {
            if (actorSide.CurrentBattlePokemon.IsMultiTurnMoveActive())
            {
                return Selection.MakeContinueMultiTurnMove(actorSide.CurrentBattlePokemon,
                                                           battle.PlayerSide.CurrentBattlePokemon);
            }
            else if (actorSide.CurrentBattlePokemon.PartiallyTrapped)
            {
                return Selection.MakeEmptyFight();
            }
            else
            {
                return MakeRandomFightSelection(battle, actorSide);
            }
        }

        private Selection MakeRandomFightSelection(Battle battle, Side actorSide)
        {
            return Selection.MakeFight(actorSide.CurrentBattlePokemon,
                                       battle.PlayerSide.CurrentBattlePokemon,
                                       PickRandomMove(actorSide));
        }

        private Move PickRandomMove(Side actorSide)
        {
            var poke = actorSide.CurrentBattlePokemon;
            
            Move move = null;
            while (move == null)
            {
                int rando = rng.Next(1, 5);
                if (rando == 1 &&
                    poke.Move1 != null)
                {
                    move = poke.Move1;
                }
                else if (rando == 2 &&
                         poke.Move2 != null)
                {
                    move = poke.Move2;
                }
                else if (rando == 3 &&
                         poke.Move3 != null)
                {
                    move = poke.Move3;
                }
                else if (rando == 4 &&
                         poke.Move4 != null)
                {
                    move = poke.Move4;
                }
            }
            return move;
        }

        public async Task<Selection> MakeForcedSwitchSelection(Battle battle, Side actorSide)
        {
            var availablePokemon = actorSide.Party.Where(p => p.Status != Status.Fainted).ToList();
            return Selection.MakeSwitchOut(actorSide.CurrentBattlePokemon, battle.OpponentSide.CurrentBattlePokemon, availablePokemon[rng.Next(availablePokemon.Count())]);
        }

        public Task<Move> PickMoveToMimic(Side opponentSide)
        {
            throw new NotImplementedException();
        }
    }
}