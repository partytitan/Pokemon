using System;
using System.Collections.Generic;
using System.Text;
using Client.World.Events;

namespace Client.Services.World
{
    internal interface IEventRunner
    {
        void RunEvents(IList<IEvent> events);
    }
}
