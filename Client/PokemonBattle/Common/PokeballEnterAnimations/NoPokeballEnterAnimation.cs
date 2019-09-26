using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.Common.PokeballEnterAnimations
{
    internal class NoPokeballEnterAnimation : IPokeballEnterAnimation
    {
        public bool IsDone { get; set; }

        public void Update(GameTime gameTime, PokeballData pokeballData)
        {
            IsDone = true;
        }
    }
}
