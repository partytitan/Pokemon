using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.TrainerSprites
{
    class TrainerOpponentSprite : TrainerSprite
    {
        public TrainerOpponentSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(-64, GameBase.Height/2/10);
            WantedPosition = new Vector2(GameBase.Width / 2 / 3 *2, GameBase.Height / 2 / 10);
        }

        protected override void Move(GameTime gameTime)
        {
            Position += new Vector2(3, 0);
        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(304, GameBase.Height / 2 / 10);
        }
    }
}
