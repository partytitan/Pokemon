using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using GameLogic.Battles;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.UI
{
    class PlayerPokemonStateBar : PokemonStateBar
    {
        private double directionCounter;
        private bool isGoingUp;

        public PlayerPokemonStateBar(BattlePokemon pokemonData) : base(pokemonData)
        {
            BasePosition = new Vector2(ScreenBattle.ArenaSize.Width * 0.6f, ScreenBattle.ArenaSize.Height * 0.65f);
            directionCounter = 0;
            isGoingUp = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            directionCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (directionCounter > 500)
            {
                BasePosition.Y += isGoingUp ? 1 : -1;
                directionCounter = 0;
                isGoingUp = !isGoingUp;
            }
        }
    }
}
