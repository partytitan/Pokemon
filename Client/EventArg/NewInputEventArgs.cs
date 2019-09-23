using System;
using System.Collections.Generic;
using System.Text;

namespace Client.EventArg
{
    internal class NewInputEventArgs : EventArgs
    {
        public GameLogic.Common.Inputs Inputs { get; set; }

        public NewInputEventArgs(GameLogic.Common.Inputs inputs)
        {
            Inputs = inputs;
        }
    }
}
