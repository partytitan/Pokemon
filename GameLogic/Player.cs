using System.Collections.Generic;
using GameLogic.Common;
using GameLogic.Data;
using GameLogic.PokemonData;
using GameLogic.Trainers;

namespace GameLogic
{
    public class Player : Trainer
    {
        public string Identity { get; set; }

        public WarpData WarpData { get; set; }

        public Directions CurrentDirection { get; set; }

        public Player(string name, List<Pokemon> pokemon, WarpData warpData, Directions currentDirection) : base(name, pokemon)
        {
            this.WarpData = warpData;
            this.CurrentDirection = currentDirection;
        }
    }
}