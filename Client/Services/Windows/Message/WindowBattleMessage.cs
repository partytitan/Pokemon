using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Client.Services.Content;
using Microsoft.Xna.Framework;

namespace Client.Services.Windows.Message
{
    internal class WindowBattleMessage : WindowMessage
    {
        public WindowBattleMessage(string text, Input input, Rectangle target) : base(new Vector2(target.X, target.Y), target.Width, target.Height, text, input)
        {
            Color = Color.Transparent;
            FontColor = Color.Black;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            Texture = contentLoader.LoadTexture("Windows/battleFrame");
            base.LoadContent(contentLoader);
        }
    }
}
