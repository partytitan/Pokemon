using System;
using System.Collections.Generic;
using System.Text;
using Client.Services;
using Client.Services.World;
using Client.World.Components;
using Client.World.Events;
using Client.World.Interfaces;
using GameLogic.Common;

namespace Client.World.EventTriggers
{
    internal class EventTriggerEyeContact : EventTrigger
    {
        private const int Range = 4;
        private readonly IWorldData worldData;
        private bool hasTriggerd;

        public EventTriggerEyeContact(IComponentOwner owner, IEventRunner eventRunner, IList<IEvent> events, IWorldData worldData) : base(owner, eventRunner, events)
        {
            this.worldData = worldData;
        }

        protected override bool ShouldTriggerEvents()
        {
            if (hasTriggerd)
                return false;

            var sprite = Owner.GetComponent<Sprite>();
            var playerSprite = worldData.GetWorldObject("mainPlayer").GetComponent<Sprite>();
            var currentDirection = (Directions)(sprite.DrawFrame.Y / sprite.DrawFrame.Height);
            var currentDirectionVector = UtilityService.ConvertDirectionToVector(currentDirection);
            for (int n = 0; n < Range; n++)
            {
                var position = sprite.TilePosition + currentDirectionVector * (n + 1);
                if (playerSprite.TilePosition == position)
                {
                    hasTriggerd = true;
                    return true;
                }
                var collision = Owner.GetComponent<Collision>();
                if (collision.CheckCollision<IPreMoveCollisionComponent>((int)position.X, (int)position.Y))
                    return false;
            }
            return false;
        }
    }
}
