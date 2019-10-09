using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Emotions
{
    internal interface IEmotion
    {
        bool IsDone { get; }
        void PlayEmotion(int xTilePosition, int yTilePosition);
        void LoadContent(IContentLoader contentLoader);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
