using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Client.EventArg;
using Client.Inputs;
using Client.Services;
using Client.Services.World;
using Client.World.Components;
using Client.World.Events;
using Client.World.Interfaces;
using GameLogic.Common;
using Microsoft.Xna.Framework;

namespace Client.World.EventTriggers
{
    internal class EventTriggerPlayerInteract : EventTrigger
    {
        private readonly int range;
        private readonly Input input;
        private readonly IWorldData worldData;
        private bool checking;

        public EventTriggerPlayerInteract(IComponentOwner owner, IEventRunner eventRunner, IList<IEvent> events, Input input, IWorldData worldData, int range = 1) : base(owner, eventRunner, events)
        {
            this.input = input;
            this.worldData = worldData;
            this.range = range;
            this.input.NewInputEvent += OnNewInput;
            this.input.ThrottleInput = true;
        }

        private void OnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if(checking)
                return;
            if(worldData.MainPlayer.IsInteracting)
                return;
            switch (newInputEventArgs.Inputs)
            {
                case GameLogic.Common.Inputs.A:
                    TriggerEvents();
                    break;

                default:
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            input.Update(gameTime);
        }

        private void TriggerEvents()
        {
            checking = true;
            var sprite = Owner.GetComponent<Sprite>();
            var playerSprite = worldData.GetWorldObject("mainPlayer").GetComponent<Sprite>();
            var currentDirection = playerSprite.CurrentDirection;
            var currentDirectionVector = UtilityService.ConvertDirectionToVector(currentDirection);
            for (int n = 0; n < range; n++)
            {
                var position = playerSprite.TilePosition + currentDirectionVector * (n + 1);
                if (position == sprite.TilePosition)
                    eventRunner.RunEvents(events);
            }

            checking = false;
        }
    }
}
