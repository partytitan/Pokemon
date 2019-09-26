using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using GameLogic.PokemonData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.UI
{
    class TrainerOpponentPokemonStatus : TrainerPokemonStatus
    {
        public override bool IsDone => Speed < 0.1f;

        public TrainerOpponentPokemonStatus(IList<Pokemon> pokemons) : base(pokemons)
        {
            Position = new Vector2(0,  ScreenBattle.ArenaSize.Height * 0.375f - PokemonBallSize.Height);
            Speed = 5.0f;
        }

        public override void StartMoveOut()
        {
            Speed = 15.0f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BarTexture, Position - new Vector2(PokemonBallSize.Width * 3 + BarSize.Width, -PokemonBallSize.Height), BarSize, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            for (int n = 0; n < PokemonBallTextures.Count; n++)
            {
                spriteBatch.Draw(PokemonBallTextures[n], Position - new Vector2(PokemonBallSize.Width * 6 + (PokemonBallSize.Width + 1) * n, 0), PokemonBallSize, Color.White);
            }
        }
    }
}
