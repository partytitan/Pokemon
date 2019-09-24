using Client.Services.World;
using Client.World.Events;
using Client.World.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Client.World.EventTriggers
{
    internal abstract class EventTrigger : Component, IUpdateComponent
    {
        private readonly IEventRunner eventRunner;
        private readonly IList<IEvent> events;

        protected EventTrigger(IComponentOwner owner, IEventRunner eventRunner, IList<IEvent> events) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.events = events;
        }

        public void Update(GameTime gameTime)
        {
            if (ShouldTriggerEvents())
            {
                eventRunner.RunEvents(events);
            }
        }

        protected abstract bool ShouldTriggerEvents();
    }
}