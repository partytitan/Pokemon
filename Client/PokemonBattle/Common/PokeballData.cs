using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Client.PokemonBattle.Common
{
    internal class PokeballData
    {
        public const int PokeballWidth = 12;
        public const int PokeballHeight = 12;

        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public string TextureName { get; set; }

        public PokeballData(Vector2 position, string textureName)
        {
            Position = position;
            TextureName = textureName;
            Color = Color.White;
            Rotation = 0.0f;
        }
    }

}
