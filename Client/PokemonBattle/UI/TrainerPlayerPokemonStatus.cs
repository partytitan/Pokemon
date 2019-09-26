using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using GameLogic.PokemonData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.UI
{
    internal class TrainerPlayerPokemonStatus : TrainerPokemonStatus
    {
        public override bool IsDone => Speed > -0.1f;

        public TrainerPlayerPokemonStatus(IList<Pokemon> pokemons) : base(pokemons)
        {
            Position = new Vector2(ScreenBattle.ArenaSize.Width, ScreenBattle.ArenaSize.Height * 0.875f - PokemonBallSize.Height);
            Speed = -5.0f;
        }

        public override void StartMoveOut()
        {
            Speed = -15.0f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BarTexture, Position + new Vector2(PokemonBallSize.Width*4, PokemonBallSize.Height), BarSize, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);

            for (int n = 0; n < PokemonBallTextures.Count; n++)
            {
                spriteBatch.Draw(PokemonBallTextures[n], Position + new Vector2(PokemonBallSize.Width*6 + (PokemonBallSize.Width + 1) * n, 0), PokemonBallSize, Color.White);
            }
        }
    }
}
