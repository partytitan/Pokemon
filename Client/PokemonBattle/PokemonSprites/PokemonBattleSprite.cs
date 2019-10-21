using System.IO;
using Client.Services.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.PokemonSprites
{
    class PokemonBattleSprite
    {
        private Texture2D texture;
        private readonly PokemonBattleSpriteData pokemonBattleSpriteDate;

        public PokemonBattleSprite(PokemonBattleSpriteData pokemonBattleSpriteDate)
        {
            this.pokemonBattleSpriteDate = pokemonBattleSpriteDate;
        }

        public PokemonBattleSpriteData GetPokemonBattleSpriteData()
        {
            return pokemonBattleSpriteDate;
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            texture = contentLoader.LoadTexture(Path.Combine("Pokemon", pokemonBattleSpriteDate.PokemonFacing.ToString(), pokemonBattleSpriteDate.TextureName));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
                spriteBatch.Draw(texture, pokemonBattleSpriteDate.Rectangle, pokemonBattleSpriteDate.DrawRectangle,
                    pokemonBattleSpriteDate.Color, 0f,
                    new Vector2(PokemonBattleSpriteData.TextureWidth / 2, PokemonBattleSpriteData.TextureHeight / 2),
                    SpriteEffects.None, 0);
        }
    }
}
