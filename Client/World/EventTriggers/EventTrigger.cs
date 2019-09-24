using Client.Services.World;
using Client.World.Events;
using Client.World.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Client.World.EventTriggers
{
    internal abstract class EventTrigger : Component, IUpdateComponent
    {
        protected readonly IEventRunner eventRunner;
        protected readonly IList<IEvent> events;

        protected EventTrigger(IComponentOwner owner, IEventRunner eventRunner, IList<IEvent> events) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.events = events;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (ShouldTriggerEvents())
            {
                eventRunner.RunEvents(events);
            }
        }

        protected virtual bool ShouldTriggerEvents()
        {
            return false;
        }
    }
}