using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Client.Services.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Events
{
    internal interface IEvent
    {
        bool IsDone { get; }
        void Initialize(IWorldData worldData);
        void LoadContent(IContentLoader contentLoader);
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
