using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.PokemonBattle.Common.PokeballEnterAnimations;
using Client.PokemonBattle.PokemonSprites.PokemonEnterBattleAnimations;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Common
{
    internal class PokeballSprite
    {
        private const int EffectCount = 30;
        private const int TimeUntilOpen = 200;
        private const int TimeOpen = 1000;


        private readonly PokeballData pokeballData;
        private readonly IPokeballEnterAnimation pokeBallEnterAnimation;
        private readonly IPokemonEnterBattleAnimation pokemonEnterBattleAnimation;
        private readonly List<PokeballOpenEffect> pokeballOpenEffects;
        private Texture2D pokeballTexture;
        private IContentLoader contentLoader;
        private Random rnd;
        private double counter;
        private bool isOpen;

        public bool IsDone { get; set; }

        public PokeballSprite(PokeballData pokeballData, IPokeballEnterAnimation pokeballEnterAnimation, IPokemonEnterBattleAnimation pokemonEnterBattleAnimation)
        {
            this.pokeballData = pokeballData;
            this.pokeBallEnterAnimation = pokeballEnterAnimation;
            this.pokemonEnterBattleAnimation = pokemonEnterBattleAnimation;
            pokeballOpenEffects = new List<PokeballOpenEffect>();
            rnd = new Random();
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            pokeballTexture = contentLoader.LoadTexture(pokeballData.TextureName);
            this.contentLoader = contentLoader;
        }

        public void Update(GameTime gameTime)
        {
            if (!pokeBallEnterAnimation.IsDone)
            {
                pokeBallEnterAnimation.Update(gameTime, pokeballData);
                return;
            }
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (!isOpen && counter > TimeUntilOpen)
            {
                isOpen = true;
                counter = 0;
                CreatePokeballOpenEffects();
                pokemonEnterBattleAnimation.StartBattleAnimation();
            }
            if (isOpen)
            {
                UpdateOpenPokeball(gameTime);
            }
        }

        private void UpdateOpenPokeball(GameTime gameTime)
        {
            if (counter < TimeOpen)
            {
                pokeballOpenEffects.ForEach(p => p.Update(gameTime));
            }
            if (!pokemonEnterBattleAnimation.IsDone)
            {
                pokemonEnterBattleAnimation.Update(gameTime);
            }
            IsDone = counter > TimeOpen && pokemonEnterBattleAnimation.IsDone;
        }

        private void CreatePokeballOpenEffects()
        {
            pokeballOpenEffects.Clear();
            for (int n = 0; n < EffectCount; n++)
            {
                Vector2 direction;
                do
                {
                    //Get a direction between -1 and 1.
                    direction = new Vector2((float)rnd.NextDouble() * 2 - 1, (float)rnd.NextDouble() * 2 - 1);
                } while (pokeballOpenEffects.Any(p => p.Direction == direction));
                var pokeballOpenEffect = new PokeballOpenEffect(pokeballData.Position, direction);
                pokeballOpenEffect.LoadContent(contentLoader);
                pokeballOpenEffects.Add(pokeballOpenEffect);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsDone) return;
            spriteBatch.Draw(pokeballTexture, pokeballData.Position,
                new Rectangle(PokeballData.PokeballWidth * (isOpen ? 1 : 0), 0, PokeballData.PokeballWidth, PokeballData.PokeballHeight), pokeballData.Color,
                pokeballData.Rotation, new Vector2(PokeballData.PokeballWidth / 2, PokeballData.PokeballHeight / 2), Vector2.One, SpriteEffects.None, 0);
            pokeballOpenEffects.ForEach(p => p.Draw(spriteBatch));
        }
    }
}
