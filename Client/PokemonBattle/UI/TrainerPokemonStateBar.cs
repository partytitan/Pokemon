using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Client.Services.Content;
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

        public override void LoadContent(IContentLoader contentLoader)
        {
            base.LoadContent(contentLoader);
            barTexture = contentLoader.LoadTexture("Battle/Gui/PlayerStatusBox");
        }
    }
}
