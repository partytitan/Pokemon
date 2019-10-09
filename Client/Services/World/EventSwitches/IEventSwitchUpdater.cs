using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Services.World.EventSwitches
{
    internal interface IEventSwitchUpdater
    {
        void UpdateEventSwitch(int id, bool on);
    }
}
