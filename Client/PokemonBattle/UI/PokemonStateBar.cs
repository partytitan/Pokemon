using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using GameLogic.Battles;
using GameLogic.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.UI
{
    abstract class PokemonStateBar
    {
        private const int BarWidth = 110;
        private const int BarHeight = 40;
        private readonly BattlePokemon pokemonData;
        protected Texture2D barTexture;
        private Texture2D genderTexture;
        private SpriteFont font;
        protected Vector2 BasePosition;
        public HealthBar HealthBar { get; private set; }

        protected PokemonStateBar(BattlePokemon pokemonData)
        {
            this.pokemonData = pokemonData;
            HealthBar = new HealthBar(pokemonData.HP, pokemonData.MaxHP);
        }

        public virtual void LoadContent(IContentLoader contentLoader)
        {
            barTexture = contentLoader.LoadTexture("Battle/Gui/PlayerStatusBox");
            font = contentLoader.LoadFont("battleFont");
            genderTexture = pokemonData.Pokemon.Gender == Genders.Male
                ? contentLoader.LoadTexture("Battle/Gui/MaleIcon")
                : contentLoader.LoadTexture("Battle/Gui/FemaleIcon");
            HealthBar.LoadContent(contentLoader);
        }

        public virtual void Update(GameTime gameTime)
        {
            HealthBar.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barTexture, new Rectangle((int)BasePosition.X, (int)BasePosition.Y, BarWidth, BarHeight), Color.White);
            spriteBatch.DrawString(font, pokemonData.Name, new Vector2(BasePosition.X + 17, BasePosition.Y + 5), Color.Gray);
            spriteBatch.Draw(genderTexture, new Vector2(BasePosition.X + 20 + font.MeasureString(pokemonData.Name).X, BasePosition.Y + 5), Color.White);
            spriteBatch.DrawString(font, $"Lv{pokemonData.Level}", new Vector2(BasePosition.X + 80, BasePosition.Y + 5), Color.Gray);
            HealthBar.Draw(spriteBatch, BasePosition);
        }
    }
}
