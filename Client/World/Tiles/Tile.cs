using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Tiled.Serialization;

namespace Client.World.Tiles
{
    public abstract class Tile
    {
        public const int Width = 16;
        public const int Height = 16;

        public int XTilePosition { get; set; }
        public int YTilePosition { get; set; }
    }
}