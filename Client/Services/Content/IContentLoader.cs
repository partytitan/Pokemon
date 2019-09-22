using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Tiled;
using MyContentPipeline.Data;

namespace Client.Services.Content
{
    public interface IContentLoader
    {
        Texture2D LoadTexture(string textureName);
        SpriteFont LoadFont(string fontName);
        TiledMap LoadMap(string mapName);
        MapData LoadMapData(string mapName);
    }
}
