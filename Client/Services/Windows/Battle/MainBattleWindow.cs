using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Client.EventArg;
using Client.Inputs;
using Client.Services.Content;
using Client.Services.Windows.Message;
using GameLogic.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Client.Services.Windows.Battle
{
    class MainBattleWindow: Window
    {
        private readonly Vector2 position;
        private readonly int width;
        private readonly int height;
        private readonly Input input;
        private SpriteFont font;

        private Color FontColor { get; set; }
        private List<Option> display;
        private MainMenuState selectedState;

        public MainBattleWindow(Vector2 position, int width, int height, Input input) : base(position, width, height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.input = input;
            this.input.NewInput += InputOnNewInput;
            this.input.ThrottleInput = true;
            FontColor = Color.Gray;

            display = new List<Option>
            {
                new Option(MainMenuState.FIGHT.ToString(),
                    new Vector2(position.X + width * 0.25f, position.Y + height * 0.25f)),
                new Option(MainMenuState.BAG.ToString(),
                    new Vector2(position.X + width * 0.75f, position.Y + height * 0.25f)),
                new Option(MainMenuState.POKEMON.ToString(),
                    new Vector2(position.X + width * 0.25f, position.Y + height * 0.75f)),
                new Option(MainMenuState.RUN.ToString(),
                    new Vector2(position.X + width * 0.75f, position.Y + height * 0.75f))
            };
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            Texture = contentLoader.LoadTexture("Windows/battleFrame");
            font = contentLoader.LoadFont("textBoxFont");
        }

        public override void Update(GameTime gameTime)
        {
            input.Update(gameTime);
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            switch (newInputEventArgs.Inputs)
            {
                case GameLogic.Common.Inputs.Left:
                    
                    break;
                case GameLogic.Common.Inputs.Up:
                    break;
                case GameLogic.Common.Inputs.Right:
                    break;
                case GameLogic.Common.Inputs.Down:
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            foreach (var option in display)
            {
                spriteBatch.DrawString(font, (false ? "> ": "") + option.text, option.position, Color.Gray);
            }
        }
    }
}
