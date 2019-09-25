using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.TrainerSprites
{
    internal class TrainerPlayerSprite : TrainerSprite
    {
        private const int FrameCount = 4;
        private const int FrameTime = 100;

        private double counter;
        private int frameIndex;
        private int speed;
        private bool isMovingOut;

        public TrainerPlayerSprite(string textureName) : base(textureName)
        {
            Position = new Vector2(GameBase.Width / 2, GameBase.Height / 2 - 60 - TrainerTextureHeight);
            WantedPosition = new Vector2(GameBase.Width / 2 / 3 - TrainerTextureWidth, GameBase.Height / 2 - 60 - TrainerTextureHeight);
            speed = 3;
            isMovingOut = false;
            frameIndex = 0;
        }

        protected override void Move(GameTime gameTime)
        {
            Position -= new Vector2(speed, 0);
            if (isMovingOut && frameIndex < FrameCount)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter > FrameTime)
                {
                    counter = 0;
                    frameIndex++;
                    DrawRectangle = new Rectangle(TrainerTextureWidth * frameIndex, 0, TrainerTextureWidth, TrainerTextureHeight);
                }
            }

        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(-64, 48);
            speed = 1;
            isMovingOut = true;
        }
    }
}
