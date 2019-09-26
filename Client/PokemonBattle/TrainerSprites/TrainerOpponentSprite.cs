using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.TrainerSprites
{
    class TrainerOpponentSprite : TrainerSprite
    {
        public TrainerOpponentSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(-TrainerTextureWidth, ScreenBattle.ArenaSize.Height * 0.1f);
            WantedPosition = new Vector2(ScreenBattle.ArenaSize.Width * 0.66f, ScreenBattle.ArenaSize.Height * 0.1f);
        }

        protected override void Move(GameTime gameTime)
        {
            Position += new Vector2(3, 0);
        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(ScreenBattle.ArenaSize.Width, ScreenBattle.ArenaSize.Height * 0.1f);
        }
    }
}
