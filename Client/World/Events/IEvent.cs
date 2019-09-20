using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Events
{
    internal interface IEvent
    {
        bool IsDone { get; }
        void Initialize();
        void LoadContent(IContentLoader contentLoader);
        void Update(double gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
