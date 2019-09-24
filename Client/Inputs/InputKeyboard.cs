using Microsoft.Xna.Framework.Input;

namespace Client.Inputs
{
    internal class InputKeyboard : Input
    {
        private KeyboardState keyboardState;
        private KeyboardState lasKeyboardState;
        private Keys lastKey;

        protected override void CheckInput(double gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyUp(lastKey) && lastKey != Keys.None)
            {
                SendNewInput(GameLogic.Common.Inputs.None);
            }

            CheckKeyState(Keys.Left, GameLogic.Common.Inputs.Left);
            CheckKeyState(Keys.Up, GameLogic.Common.Inputs.Up);
            CheckKeyState(Keys.Right, GameLogic.Common.Inputs.Right);
            CheckKeyState(Keys.Down, GameLogic.Common.Inputs.Down);
            CheckKeyState(Keys.A, GameLogic.Common.Inputs.A);

            lasKeyboardState = keyboardState;
        }

        private void CheckKeyState(Keys key, GameLogic.Common.Inputs sendInputs)
        {
            if (keyboardState.IsKeyDown(key))
            {
                if (!ThrottleInput || (ThrottleInput && lasKeyboardState.IsKeyUp(key)))
                {
                    SendNewInput(sendInputs);
                    lastKey = key;
                }
            }
        }
    }
}