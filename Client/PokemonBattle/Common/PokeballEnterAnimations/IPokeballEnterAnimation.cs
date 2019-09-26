using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.Common.PokeballEnterAnimations
{
    internal interface IPokeballEnterAnimation
    {
        bool IsDone { get; }
        void Update(GameTime gameTime, PokeballData pokeballData);
    }
}
