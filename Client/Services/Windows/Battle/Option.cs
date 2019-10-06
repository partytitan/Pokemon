using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Services.Windows.Battle
{
    class Option
    {
        public readonly string text;
        public readonly Vector2 position;

        public Option(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
        }
    }
}
