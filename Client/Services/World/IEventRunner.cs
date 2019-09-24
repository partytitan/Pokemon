using Client.World.Events;
using System.Collections.Generic;

namespace Client.Services.World
{
    internal interface IEventRunner
    {
        void RunEvents(IList<IEvent> events);
    }
}