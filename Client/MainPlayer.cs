using System.Collections.Generic;
using Client.Inputs;
using GameLogic;
using GameLogic.Common;
using GameLogic.Data;
using GameLogic.PokemonData;
using GameLogic.Trainers;

namespace Client
{
    internal class MainPlayer : Player
    {
        public InputKeyboard Input { get; }

        public bool CanMove { get; set; }
        public bool IsInteracting { get; set; }


        public MainPlayer(string name, List<Pokemon> pokemon, WarpData warpData, Directions currentDirection) : base(name, pokemon, warpData, currentDirection)
        {
            this.Input = new InputKeyboard();
            this.CanMove = true;
            this.IsInteracting = false;
        }
    }
}