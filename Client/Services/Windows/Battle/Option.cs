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
        public readonly int Id;
        public readonly MainMenuState State;
        public readonly string Text;
        public Option(string text, MainMenuState state, int id = 0)
        {
            this.Text = text;
            this.State = state;
            this.Id = id;
        }
    }
}
