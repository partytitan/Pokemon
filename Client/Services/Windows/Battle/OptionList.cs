using System;
using System.Collections.Generic;
using System.Text;
using Client.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.Services.Windows.Battle
{
    class OptionList
    {
        private readonly Rectangle bounds;
        private int currentSelection;
        private const int OptionsPerLine = 2;
        private readonly Option[] options;
        private readonly WindowBattle windowBattle;
        private readonly Vector2 Margin;

        public OptionList(Rectangle bounds, WindowBattle windowBattle, params Option[] options)
        {
            this.bounds = bounds;
            this.options = options;
            this.windowBattle = windowBattle;
            this.Margin = new Vector2(bounds.Width / OptionsPerLine, bounds.Height + (options.Length / OptionsPerLine));
        }

        public Option SelectedOption => options[currentSelection];

        public void MoveSelection(GameLogic.Common.Inputs input)
        {
            switch (input)
            {
                case GameLogic.Common.Inputs.Left:
                    if (currentSelection % OptionsPerLine > 0)
                        currentSelection--;
                    break;
                case GameLogic.Common.Inputs.Up:
                    if (currentSelection >= OptionsPerLine)
                        currentSelection -= OptionsPerLine;
                    break;
                case GameLogic.Common.Inputs.Right:
                    if (currentSelection % OptionsPerLine < OptionsPerLine - 1)
                        currentSelection++;
                    break;
                case GameLogic.Common.Inputs.Down:
                    if (currentSelection + OptionsPerLine < options.Length)
                        currentSelection += OptionsPerLine;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            this.windowBattle.Draw(spriteBatch);
            for (var i = 0; i < options.Length; i++)
            {
                var text = (i == currentSelection ? "> " : "") + options[i].text;
                var testSize = font.MeasureString(text);
                

                var position = new Vector2((Margin.X / 2 - testSize.X / 2) + bounds.X + (i % OptionsPerLine) * Margin.X,  testSize.Y + bounds.Y + (i / OptionsPerLine) * bounds.Height / (options.Length / OptionsPerLine));
                spriteBatch.DrawString(font, text, position, i == currentSelection ? Color.Black : Color.Gray);
            }
        }
    }
}
