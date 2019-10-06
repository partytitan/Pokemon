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
        public readonly bool isFolder;

        public Option(string text, bool isFolder = false)
        {
            this.text = text;
            this.isFolder = isFolder;
        }
    }
}
