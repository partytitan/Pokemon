using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.PokemonSprites.PokemonEnterBattleAnimations
{
    class GrowPokemonEnterBattleAnimation : TransparentPokemonEnterBattleAnimation
    {
        public GrowPokemonEnterBattleAnimation(PokemonBattleSpriteData pokemonBattleSpriteData) : base(pokemonBattleSpriteData)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (PokemonBattleSpriteData.Position.Y > ScreenBattle.ArenaSize.Height - PokemonBattleSpriteData.Height / 2)
            {
                PokemonBattleSpriteData.Position -= new Vector2(0, SizeGrowthSpeed * 2);
            }
        }
    }
}
