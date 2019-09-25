using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework;

namespace Client.Services.Windows
{
    class WindowBattle : Window
    {
        public WindowBattle(Vector2 position, int width, int height) : base(position, width, height)
        {
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            Texture = contentLoader.LoadTexture("Windows/battleFrame");
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
