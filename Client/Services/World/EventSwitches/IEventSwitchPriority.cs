using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Services.World.EventSwitches
{
    internal interface IEventSwitchPriority
    {
        IList<int> GetPrioritizedEventIds(IList<int> eventSwitchIds);
    }
}
