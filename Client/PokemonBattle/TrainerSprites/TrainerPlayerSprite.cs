using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
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
            Position = new Vector2(ScreenBattle.ArenaSize.Width, ScreenBattle.ArenaSize.Height - TrainerTextureHeight);
            WantedPosition = new Vector2(ScreenBattle.ArenaSize.Width * 0.33f - TrainerTextureWidth, ScreenBattle.ArenaSize.Height - TrainerTextureHeight);
            speed = 3;
            frameIndex = 0;
        }

        protected override void Move(GameTime gameTime)
        {
            Position -= new Vector2(speed, 0);
        }

        public override void StartMoveOut()
        {
            WantedPosition = new Vector2(0 - TrainerTextureWidth, ScreenBattle.ArenaSize.Height - TrainerTextureHeight);
            speed = 1;
        }
    }
}
