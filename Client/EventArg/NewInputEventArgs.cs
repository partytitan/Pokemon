using System;
using System.Collections.Generic;
using System.Text;

namespace Client.EventArg
{
    internal class NewInputEventArgs : EventArgs
    {
        public Common.Inputs Inputs { get; set; }

        public NewInputEventArgs(Common.Inputs inputs)
        {
            Inputs = inputs;
        }
    }
}
