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
using System.Threading.Tasks;
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
        private readonly GameLogic.Battles.Battle battle;
        private readonly TaskCompletionSource<Selection> selectionMade;
        private SpriteFont font;

        private Color FontColor { get; set; }
        private OptionList currentOptionList;

        private readonly WindowBattle rightWindowBattle;
        private readonly WindowBattle leftWindowBattle;


        public MainBattleWindow(Rectangle bounds, Input input, Side actorSide, GameLogic.Battles.Battle battle, TaskCompletionSource<Selection> selectionMade) : base(bounds.Location.ToVector2(), bounds.Width, bounds.Height)
        {
            this.bounds = bounds;
            this.leftMenuBounds = new Rectangle(bounds.X, bounds.Y, (int)(bounds.Width * 0.6), bounds.Height);
            this.rightMenuBounds = new Rectangle((int)(bounds.Width * 0.6), bounds.Y, (int)(bounds.Width * 0.4), bounds.Height);
            this.actorSide = actorSide;
            this.battle = battle;
            this.selectionMade = selectionMade;

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
                switch (currentOptionList.SelectedOption.State)
                {
                    case MainMenuState.FIGHT:
                        MoveSelectionMenu();
                        break;
                    case MainMenuState.POKEMON:
                        PokemonSelectionMenu();
                        break;
                    case MainMenuState.BAG:
                        break;
                    case MainMenuState.RUN:
                        break;
                    case MainMenuState.POKEMON1:
                        break;
                    case MainMenuState.POKEMON2:
                        break;
                    case MainMenuState.POKEMON3:
                        break;
                    case MainMenuState.POKEMON4:
                        break;
                    case MainMenuState.POKEMON5:
                        break;
                    case MainMenuState.POKEMON6:
                        break;
                    case MainMenuState.MOVE1:
                        IsDone = true;
                        selectionMade.TrySetResult(Selection.MakeFight(actorSide.CurrentBattlePokemon,
                            battle.OpponentSide.CurrentBattlePokemon, actorSide.CurrentBattlePokemon.Move1));
                        break;
                    case MainMenuState.MOVE2:
                        break;
                    case MainMenuState.MOVE3:
                        break;
                    case MainMenuState.MOVE4:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            currentOptionList.MoveSelection(newInputEventArgs.Inputs);
        }

        private void MainMenu()
        {
            currentOptionList = new OptionList(new Rectangle(rightMenuBounds.Location, rightMenuBounds.Size), rightWindowBattle,
                new Option(MainMenuState.FIGHT.ToString(), MainMenuState.FIGHT), new Option(MainMenuState.BAG.ToString(), MainMenuState.BAG),
                new Option(MainMenuState.POKEMON.ToString(), MainMenuState.POKEMON), new Option(MainMenuState.RUN.ToString(), MainMenuState.RUN));
        }
        private void MoveSelectionMenu()
        {
            
            currentOptionList = new OptionList(new Rectangle(leftMenuBounds.Location, leftMenuBounds.Size), leftWindowBattle, new Option(actorSide.CurrentBattlePokemon.Move1.Name, MainMenuState.MOVE1), new Option(actorSide.CurrentBattlePokemon.Move2.Name, MainMenuState.MOVE2),
                new Option(actorSide.CurrentBattlePokemon.Move3.Name, MainMenuState.MOVE3), new Option(actorSide.CurrentBattlePokemon.Move4.Name, MainMenuState.MOVE4));
        }

        private void PokemonSelectionMenu()
        {
            List<Option> options = new List<Option>();
            foreach (var pokemon in actorSide.Party)
            {
                options.Add(new Option(pokemon.Nickname + " - " + pokemon.Status.ToString(), MainMenuState.POKEMON1));
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
