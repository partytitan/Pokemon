using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Client.Services.Windows
{
    internal abstract class Window
    {
        private const int CornerWidth = 5;
        private const int CornerHeight = 5;
        private const int SideWidth = 5;
        private const int SideHeight = 6;
        private const int TopWidth = 6;
        private const int TopHeight = 5;
        private const int MiddleWidth = 6;
        private const int MiddleHeight = 6;

        private Texture2D texture;
        protected Vector2 Position;
        protected int Height;
        protected int Width;
        public bool IsDone { get; protected set; }

        protected Window(Vector2 position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }
        public virtual void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture("Windows/windowframe");
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            DrawCorners(spriteBatch);
            DrawSides(spriteBatch);
            DrawTopAndBottom(spriteBatch);
            spriteBatch.Draw(texture, new Rectangle((int)Position.X + SideWidth, (int)Position.Y + TopHeight, Width - SideWidth * 2, Height - TopHeight * 2), new Rectangle(6, 6, MiddleWidth, MiddleHeight), Color.White);
        }

        private void DrawCorners(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y, CornerWidth, CornerHeight), new Rectangle(0, 0, CornerWidth, CornerHeight), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)Position.X + Width - CornerWidth, (int)Position.Y, CornerWidth, CornerHeight), new Rectangle(11, 0, CornerWidth, CornerHeight), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)Position.X, (int)Position.Y + Height - CornerHeight, CornerWidth, CornerHeight), new Rectangle(0, 11, CornerWidth, CornerHeight), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)Position.X + Width - CornerWidth, (int)Position.Y + Height - CornerHeight, CornerWidth, CornerHeight), new Rectangle(11, 11, CornerWidth, CornerHeight), Color.White);
        }

        private void DrawSides(SpriteBatch spriteBatch)
        {
            var sideCount = (double)(Height - CornerHeight * 2) / SideHeight;
            for (int n = 0; n < Math.Floor(sideCount); n++)
            {
                var y = (int)Position.Y + SideHeight * (n + 1) - 1;
                spriteBatch.Draw(texture, new Rectangle((int)Position.X, y, SideWidth, SideHeight), new Rectangle(0, CornerHeight, SideWidth, SideHeight), Color.White);
                spriteBatch.Draw(texture, new Rectangle((int)Position.X + Width - SideWidth, y, SideWidth, SideHeight), new Rectangle(11, CornerHeight, SideWidth, SideHeight), Color.White);
            }
            if (sideCount % 1 != 0)
            {
                var y = (int)(Position.Y + SideHeight * Math.Floor(sideCount));
                var height = (int)Position.Y + Height - CornerHeight - y + 1;
                spriteBatch.Draw(texture, new Rectangle((int)Position.X, y, SideWidth, height), new Rectangle(0, CornerHeight, SideWidth, SideHeight), Color.White);
                spriteBatch.Draw(texture, new Rectangle((int)Position.X + Width - SideWidth, y, SideWidth, height), new Rectangle(11, CornerHeight, SideWidth, SideHeight), Color.White);
            }
        }

        private void DrawTopAndBottom(SpriteBatch spriteBatch)
        {
            var topCount = (double)(Width - CornerWidth * 2) / TopWidth;
            for (int n = 0; n < Math.Floor(topCount); n++)
            {
                var x = (int)Position.X + TopWidth * (n + 1) - 1;
                spriteBatch.Draw(texture, new Rectangle(x, (int)Position.Y, TopWidth, TopHeight), new Rectangle(CornerWidth, 0, TopWidth, TopHeight), Color.White);
                spriteBatch.Draw(texture, new Rectangle(x, (int)Position.Y + Height - TopHeight, TopWidth, TopHeight), new Rectangle(CornerWidth, 11, TopWidth, TopHeight), Color.White);
            }
            if (topCount % 1 != 0)
            {
                var x = (int)(Position.X + TopWidth * Math.Floor(topCount));
                var width = (int)Position.X + Width - CornerWidth - x;
                spriteBatch.Draw(texture, new Rectangle(x, (int)Position.Y, width, TopHeight), new Rectangle(CornerWidth, 0, TopWidth, TopHeight), Color.White);
                spriteBatch.Draw(texture, new Rectangle(x, (int)Position.Y + Height - TopHeight, width, TopHeight), new Rectangle(CornerWidth, 11, TopWidth, TopHeight), Color.White);
            }
        }
    }
}