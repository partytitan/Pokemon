using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Services.Windows.Message
{
    internal class MessageArrow
    {
        private const float Speed = 0.5f;
        private Vector2 position;
        private Point size = new Point(7);
        private Texture2D arrowTexture;
        private double counter;
        private bool goingDown;

        public MessageArrow(Vector2 position)
        {
            this.position = position;
            counter = 0;
            goingDown = true;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            arrowTexture = contentLoader.LoadTexture("Windows/messageArrow");
        }

        public void Update(GameTime gameTime)
        {
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (goingDown)
            {
                position += new Vector2(0, Speed);
            }
            else
            {
                position -= new Vector2(0, Speed);
            }
            if (counter > 200)
            {
                counter = 0;
                goingDown = !goingDown;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(arrowTexture, new Rectangle(position.ToPoint(), size), Color.White);
        }
    }
}
