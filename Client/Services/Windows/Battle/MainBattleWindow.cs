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
using GameLogic.Battles;

namespace Client.Services.Windows.Battle
{
    class MainBattleWindow: Window
    {
        private readonly Rectangle bounds;
        private readonly Rectangle rightMenuBounds;
        private readonly Rectangle leftMenuBounds;

        private readonly Input input;
        private readonly Side actorSide;
        private SpriteFont font;

        private Color FontColor { get; set; }
        private OptionList currentOptionList;

        private readonly WindowBattle rightWindowBattle;
        private readonly WindowBattle leftWindowBattle;


        public MainBattleWindow(Rectangle bounds, Input input, Side actorSide) : base(bounds.Location.ToVector2(), bounds.Width, bounds.Height)
        {
            this.bounds = bounds;
            this.leftMenuBounds = new Rectangle(bounds.X, bounds.Y, (int)(bounds.Width * 0.6), bounds.Height);
            this.rightMenuBounds = new Rectangle((int)(bounds.Width * 0.6), bounds.Y, (int)(bounds.Width * 0.4), bounds.Height);
            this.actorSide = actorSide;

            this.input = input;
            this.input.NewInput += InputOnNewInput;
            this.input.ThrottleInput = true;
            FontColor = Color.Gray;

            rightWindowBattle = new WindowBattle(rightMenuBounds);
            leftWindowBattle = new WindowBattle(leftMenuBounds);

            MainMenu();
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            Texture = contentLoader.LoadTexture("Windows/battleFrame");
            font = contentLoader.LoadFont("textBoxFont");
            rightWindowBattle.LoadContent(contentLoader);
            leftWindowBattle.LoadContent(contentLoader);
        }

        public override void Update(GameTime gameTime)
        {
            input.Update(gameTime);
        }

        private void InputOnNewInput(object sender, NewInputEventArgs newInputEventArgs)
        {
            if (newInputEventArgs.Inputs == GameLogic.Common.Inputs.A)
            {
                if (currentOptionList.SelectedOption.isFolder)
                {
                    switch (Enum.Parse<MainMenuState>(currentOptionList.SelectedOption.text))
                    {
                        case MainMenuState.FIGHT:
                            MoveSelectionMenu();
                            break;
                        case MainMenuState.POKEMON:
                            PokemonSelectionMenu();
                            break;
                    }
                }
                else
                {

                }
            }
            currentOptionList.MoveSelection(newInputEventArgs.Inputs);
        }

        private void MainMenu()
        {
            currentOptionList = new OptionList(new Rectangle(rightMenuBounds.Location, rightMenuBounds.Size), rightWindowBattle,
                new Option(MainMenuState.FIGHT.ToString(), true), new Option(MainMenuState.BAG.ToString()),
                new Option(MainMenuState.POKEMON.ToString(), true), new Option(MainMenuState.RUN.ToString()));
        }
        private void MoveSelectionMenu()
        {
            
            currentOptionList = new OptionList(new Rectangle(leftMenuBounds.Location, leftMenuBounds.Size), leftWindowBattle, new Option(actorSide.CurrentBattlePokemon.Move1.Name), new Option(actorSide.CurrentBattlePokemon.Move2.Name),
                new Option(actorSide.CurrentBattlePokemon.Move3.Name), new Option(actorSide.CurrentBattlePokemon.Move4.Name));
        }

        private void PokemonSelectionMenu()
        {
            List<Option> options = new List<Option>();
            foreach (var pokemon in actorSide.Party)
            {
                options.Add(new Option(pokemon.Nickname + " - " + pokemon.Status.ToString()));
            }
            currentOptionList = new OptionList(new Rectangle(leftMenuBounds.Location, leftMenuBounds.Size), leftWindowBattle, options.ToArray());
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            currentOptionList.Draw(spriteBatch, font);
        }
    }
}
