using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.PokemonSprites.PokemonEnterBattleAnimations
{
    interface IPokemonEnterBattleAnimation
    {
        bool IsDone { get; }
        void StartBattleAnimation();
        void Update(GameTime gameTime);
    }
}
