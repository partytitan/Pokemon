using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using GameLogic.PokemonData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.UI
{
    internal abstract class TrainerPokemonStatus
    {
        private const int SpeedDowngradeCooldown = 220;
        private const float SpeedDowngradeMultiplier = 0.3f;
        private readonly IList<Pokemon> pokemons;
        protected IList<Texture2D> PokemonBallTextures;
        protected Texture2D BarTexture;
        protected Vector2 Position;
        protected float Speed;
        private double counter;

        public abstract bool IsDone { get; }

        protected TrainerPokemonStatus(IList<Pokemon> pokemons)
        {
            this.pokemons = pokemons;
            PokemonBallTextures = new List<Texture2D>();
            counter = 0;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            //BarTexture = contentLoader.LoadTexture("Battle/Gui/BattleNumberOfPokemons");
            LoadPokemonBallTextures(contentLoader);
        }

        private void LoadPokemonBallTextures(IContentLoader contentLoader)
        {
            foreach (var pokemon in pokemons)
            {
                switch (pokemon.Status)
                {
                    case Status.Null:
                        PokemonBallTextures.Add(
                            contentLoader.LoadTexture(
                                $"Battle/gui/StatusPokemonBall/normal"));
                        break;
                    case Status.Fainted:
                        PokemonBallTextures.Add(
                            contentLoader.LoadTexture(
                                $"Battle/gui/StatusPokemonBall/fainted"));
                        break;
                    default:
                        PokemonBallTextures.Add(
                            contentLoader.LoadTexture(
                                $"Battle/gui/StatusPokemonBall/status"));
                        break;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (IsDone)
                return;
            Position += new Vector2(Speed, 0);
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > SpeedDowngradeCooldown)
            {
                Speed *= SpeedDowngradeMultiplier;
                counter = 0;
            }
        }

        public abstract void StartMoveOut();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
