using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Microsoft.Xna.Framework;

namespace Client.Services.Windows
{
    class WindowBattle : Window
    {
        public WindowBattle(Rectangle target) : base(new Vector2(target.X, target.Y), target.Width, target.Height)
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
