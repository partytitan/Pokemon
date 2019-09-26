using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Common
{
    internal class PokeballOpenEffect
    {
        private const int EffectWidth = 6;
        private const int EffectHeight = 6;
        private const int AnimationFrequency = 50;
        private const int EffectFrameCount = 3;

        private Vector2 position;
        private Texture2D effectTecture;
        private int animationIndex;
        private double counter;

        public Vector2 Direction { get; }

        public PokeballOpenEffect(Vector2 startPosition, Vector2 direction)
        {
            Direction = direction;
            position = startPosition;
        }


        public void LoadContent(IContentLoader contentLoader)
        {
            effectTecture = contentLoader.LoadTexture("Battle/Pokeballs/pokeball_open_effect");
        }

        public void Update(GameTime gameTime)
        {
            position += Direction;
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > AnimationFrequency)
            {
                counter = 0;
                animationIndex++;
                if (animationIndex >= EffectFrameCount)
                {
                    animationIndex = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(effectTecture, position, new Rectangle(EffectWidth * animationIndex, 0, EffectWidth, EffectHeight), Color.White);
        }
    }
}
