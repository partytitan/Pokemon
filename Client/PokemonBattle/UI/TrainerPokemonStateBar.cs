using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using GameLogic.Battles;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.UI
{
    class TrainerPokemonStateBar : PokemonStateBar
    {
        public TrainerPokemonStateBar(BattlePokemon pokemonData) : base(pokemonData)
        {
            BasePosition = new Vector2(ScreenBattle.ArenaSize.Width * 0.1f, ScreenBattle.ArenaSize.Height * 0.15f);
        }
    }
}
