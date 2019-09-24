using Client.EventArg;
using Microsoft.Xna.Framework;
using System;

namespace Client.Inputs
{
    internal abstract class Input
    {
        public static bool LockInput { get; set; }
        public bool ThrottleInput { get; set; }

        internal event EventHandler<NewInputEventArgs> NewInput;

        private double counter;
        private double cooldown;

        public event EventHandler<NewInputEventArgs> NewInputEvent
        {
            add => NewInput += value;
            remove => NewInput -= value;
        }

        protected Input()
        {
            counter = 0;
            cooldown = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (LockInput)
                return;
            if (cooldown > 0)
            {
                counter += gameTime.ElapsedGameTime.Milliseconds;
                if (counter > gameTime.ElapsedGameTime.Milliseconds)
                {
                    counter = 0;
                    cooldown = 0;
                }
                else
                {
                    return;
                }
            }
            CheckInput(gameTime.ElapsedGameTime.Milliseconds);
        }

        protected abstract void CheckInput(double gameTime);

        protected void SendNewInput(GameLogic.Common.Inputs inputs)
        {
            NewInput?.Invoke(this, new NewInputEventArgs(inputs));
        }
    }
}