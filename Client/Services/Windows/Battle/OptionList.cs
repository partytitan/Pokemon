using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Microsoft.Xna.Framework;

namespace Client.Services.Windows.Battle
{
    class OptionList
    {
        private readonly Rectangle bounds;
        private int currentSelection;
        private Option[] options;

        public OptionList(Rectangle bounds, params Option[] options)
        {
            this.bounds = bounds;
            this.options = options;
        }

        public void MoveSelection(GameLogic.Common.Inputs input)
        {
            switch (input)
            {
                case GameLogic.Common.Inputs.Left:
                    break;
                case GameLogic.Common.Inputs.Up:
                    break;
                case GameLogic.Common.Inputs.Right:
                    break;
                case GameLogic.Common.Inputs.Down:
                    break;
            }
        }
    }
}
