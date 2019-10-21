using Client.EventArg;
using Client.Inputs;
using Client.Services.Content;
using GameLogic.Battles;
using GameLogic.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Threading.Tasks;
using GameLogic.PokemonData;

namespace Client.Services.Windows.Battle
{
    internal class MainBattleWindow : Window
    {
        private readonly Side actorSide;
        private readonly GameLogic.Battles.Battle battle;
        private readonly Rectangle bounds;
        private readonly Input input;
        private readonly Rectangle leftMenuBounds;
        private readonly WindowBattle leftWindowBattle;
        private readonly Rectangle rightMenuBounds;
        private readonly WindowBattle rightWindowBattle;
        private readonly TaskCompletionSource<Selection> selectionMade;
        private OptionList currentOptionList;
        private SpriteFont font;

        private Color FontColor { get; set; }
        public MainBattleWindow(Rectangle bounds, Input input, Side actorSide, GameLogic.Battles.Battle battle, TaskCompletionSource<Selection> selectionMade, bool makeForcedPokemonSwitch = false) : base(bounds.Location.ToVector2(), bounds.Width, bounds.Height)
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

            if (makeForcedPokemonSwitch)
            {
                PokemonSelectionMenu();
            }
            else
            {
                MainMenu();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            currentOptionList.Draw(spriteBatch, font);
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
                var id = currentOptionList.SelectedOption.Id;
                switch (currentOptionList.SelectedOption.State)
                {
                    case MainMenuState.FIGHT:
                        if (id != 0)
                        {
                            IsDone = true;
                            switch (id)
                            {
                                case 1:
                                    selectionMade.TrySetResult(Selection.MakeFight(actorSide.CurrentBattlePokemon,
                                        battle.OpponentSide.CurrentBattlePokemon, actorSide.CurrentBattlePokemon.Move1));
                                    break;

                                case 2:
                                    selectionMade.TrySetResult(Selection.MakeFight(actorSide.CurrentBattlePokemon,
                                        battle.OpponentSide.CurrentBattlePokemon, actorSide.CurrentBattlePokemon.Move2));
                                    break;

                                case 3:
                                    selectionMade.TrySetResult(Selection.MakeFight(actorSide.CurrentBattlePokemon,
                                        battle.OpponentSide.CurrentBattlePokemon, actorSide.CurrentBattlePokemon.Move3));
                                    break;

                                case 4:
                                    selectionMade.TrySetResult(Selection.MakeFight(actorSide.CurrentBattlePokemon,
                                        battle.OpponentSide.CurrentBattlePokemon, actorSide.CurrentBattlePokemon.Move4));
                                    break;
                            }
                        }
                        else
                        {
                            MoveSelectionMenu();
                        }
                        break;

                    case MainMenuState.POKEMON:
                        if (id != 0)
                        {
                            IsDone = true;
                            selectionMade.TrySetResult(Selection.MakeSwitchOut(actorSide.CurrentBattlePokemon, battle.OpponentSide.CurrentBattlePokemon, actorSide.Party[id]));
                        }
                        else
                        {
                            PokemonSelectionMenu();
                        }
                        break;

                    case MainMenuState.BAG:
                        break;

                    case MainMenuState.RUN:
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
            currentOptionList = new OptionList(new Rectangle(leftMenuBounds.Location, leftMenuBounds.Size), leftWindowBattle, new Option(actorSide.CurrentBattlePokemon.Move1.Name, MainMenuState.FIGHT, 1), new Option(actorSide.CurrentBattlePokemon.Move2.Name, MainMenuState.FIGHT, 2),
                new Option(actorSide.CurrentBattlePokemon.Move3.Name, MainMenuState.FIGHT, 3), new Option(actorSide.CurrentBattlePokemon.Move4.Name, MainMenuState.FIGHT, 4));
        }

        private void PokemonSelectionMenu()
        {
            currentOptionList = new OptionList(new Rectangle(leftMenuBounds.Location, leftMenuBounds.Size), leftWindowBattle, actorSide.Party.Select((pokemon, index) => new Option(pokemon.Nickname + " - " + pokemon.Level + (pokemon.Status != Status.Null ? " - " + pokemon.Status.ToString() : ""), MainMenuState.POKEMON, index)).ToArray());
        }
    }
}