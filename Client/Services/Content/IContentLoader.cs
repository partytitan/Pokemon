using GameLogic.Data;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;

namespace Client.Services.Content
{
    public interface IContentLoader
    {
        Texture2D LoadTexture(string textureName);

        SpriteFont LoadFont(string fontName);

        TiledMap LoadMap(string mapName);

        MapData LoadMapData(string mapName);

        string[] LoadMapSpeech(string mapName);
    }
}