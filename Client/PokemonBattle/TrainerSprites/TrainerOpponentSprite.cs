using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.TrainerSprites
{
    class TrainerOpponentSprite : TrainerSprite
    {
        private int speed;
        public TrainerOpponentSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(-TrainerTextureWidth, ScreenBattle.ArenaSize.Height * 0.1f);
            WantedPosition = new Vector2(ScreenBattle.ArenaSize.Width * 0.66f, ScreenBattle.ArenaSize.Height * 0.1f);
            speed = 3;
        }

        protected override void Move(GameTime gameTime)
        {
            Position += new Vector2(speed, 0);
        }

        public override void StartMoveOut()
        {
            speed = 6;
            WantedPosition = new Vector2(ScreenBattle.ArenaSize.Width, ScreenBattle.ArenaSize.Height * 0.1f);
        }
    }
}
