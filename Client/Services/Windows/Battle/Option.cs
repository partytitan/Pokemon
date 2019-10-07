using System;
using System.Collections.Generic;
using System.Text;
using GameLogic.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Services.Windows.Battle
{
    class Option
    {
        public readonly string Text;
        public readonly MainMenuState State;

        public Option(string text, MainMenuState state)
        {
            this.Text = text;
            this.State = state;
        }
    }
}
