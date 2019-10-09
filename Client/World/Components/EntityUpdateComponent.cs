using System;
using System.Collections.Generic;
using System.Text;
using Client.EventArg;
using Client.Inputs;
using Client.Services.World;
using Client.Services.World.EventSwitches;
using Client.World.Interfaces;
using Microsoft.Xna.Framework;

namespace Client.World.Components
{
    internal class EntityUpdateComponent : Component, IUpdateComponent
    {
        private readonly IEventRunner eventRunner;
        private readonly Input input;
        private readonly IEventSwitchUpdater eventSwitchUpdater;
        private bool lastUpdate;

        public EntityUpdateComponent(IComponentOwner owner, IEventRunner eventRunner, Input input, IEventSwitchUpdater eventSwitchUpdater) : base(owner)
        {
            this.eventRunner = eventRunner;
            this.input = input;
            this.eventSwitchUpdater = eventSwitchUpdater;
            input.NewInput += InputOnNewInput;
            lastUpdate = false;
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == GameLogic.Common.Inputs.A)
            {
                lastUpdate = !lastUpdate;
                eventSwitchUpdater.UpdateEventSwitch(1, lastUpdate);
                //eventRunner.RunEvents(new List<IEvent> { new EventEmotion("player", new EmotionTrainer())});
            }
        }

        public void Update(GameTime gameTime)
        {
            input.Update(gameTime);
        }
    }
}
