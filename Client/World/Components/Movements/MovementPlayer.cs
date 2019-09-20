using System;
using System.Collections.Generic;
using System.Text;
using Client.Common;
using Client.EventArg;
using Client.Inputs;
using Client.Screens;
using Client.World.Components.Animations;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Client.World.Components.Movements
{
    internal class MovementPlayer : Movement
    {
        private readonly Input input;

        public MovementPlayer(IComponentOwner owner, float speed, Input input, Camera camera) : base(owner, speed, camera)
        {
            this.input = input;
            this.input.NewInput += OnNewInput;
        }

        private void OnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (InMovement)
                return;
            switch (newInputEventArgs.Inputs)
            {
                case Common.Inputs.Left:
                    Move(Directions.Left);
                    break;
                case Common.Inputs.Up:
                    Move(Directions.Up);
                    break;
                case Common.Inputs.Right:
                    Move(Directions.Right);
                    break;
                case Common.Inputs.Down:
                    Move(Directions.Down);
                    break;
                case Common.Inputs.None:
                    break;
                case Common.Inputs.A:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void Update(GameTime gameTime)
        {
            input.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
