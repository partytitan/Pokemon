using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.PokemonSprites
{
    class PokemonBattleSpriteData
    {
        public const int TextureWidth = 64;
        public const int TextureHeight = 64;

        public enum PokemonFacings
        {
            Front,
            Back
        };

        public string TextureName { get; set; }
        public Color Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
        public Rectangle DrawRectangle => new Rectangle(TextureWidth * (int)PokemonFacing, 0, TextureWidth, TextureHeight);
        public PokemonFacings PokemonFacing { get; set; }

        public PokemonBattleSpriteData(int width, int height, Vector2 position, Color color, string textureName, PokemonFacings pokemonFacing)
        {
            Color = color;
            TextureName = textureName;
            PokemonFacing = pokemonFacing;
            Width = width;
            Height = height;
            Position = position;
        }
    }
}
