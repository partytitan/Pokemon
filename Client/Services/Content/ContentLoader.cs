using GameLogic.Data;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameLogic;
using GameLogic.PokemonData;

namespace Client.Services.Content
{
    internal class ContentLoader : IContentLoader
    {
        private const string TextureNotFoundName = "NotFoundTexture";
        private const string FontNotFoundName = "NotFoundFont";
        private const string MapNotFoundName = "0.0";
        private const string MapDataNotFoundName = "0.0";
        private const string MapSpeechNotFoundName = "0.0";

        private readonly ContentManager contentManager;
        private readonly Dictionary<string, Texture2D> textureByName;
        private readonly Dictionary<string, SpriteFont> fontByName;
        private readonly Dictionary<string, TiledMap> mapByName;
        private readonly Dictionary<string, MapData> mapDataByName;
        private readonly Dictionary<string, string[]> mapSpeechByName;

        public ContentLoader(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            textureByName = new Dictionary<string, Texture2D>();
            fontByName = new Dictionary<string, SpriteFont>();
            mapByName = new Dictionary<string, TiledMap>();
            mapDataByName = new Dictionary<string, MapData>();
            mapSpeechByName = new Dictionary<string, string[]>();
        }

        public Texture2D LoadTexture(string textureName)
        {
            if (!textureByName.ContainsKey(textureName))
            {
                try
                {
                    var texture = contentManager.Load<Texture2D>(Path.Combine("Textures", textureName));
                    textureByName.Add(textureName, texture);
                    return texture;
                }
                catch (Exception) when (textureName != TextureNotFoundName)
                {
                    return LoadTexture(TextureNotFoundName);
                }
            }

            return textureByName[textureName];
        }

        public SpriteFont LoadFont(string fontName)
        {
            if (!fontByName.ContainsKey(fontName))
            {
                try
                {
                    var font = contentManager.Load<SpriteFont>(Path.Combine("Fonts", fontName));
                    fontByName.Add(fontName, font);
                    return font;
                }
                catch (Exception) when (fontName != FontNotFoundName)
                {
                    return LoadFont(FontNotFoundName);
                }
            }

            return fontByName[fontName];
        }

        public TiledMap LoadMap(string mapName)
        {
            if (!mapByName.ContainsKey(mapName))
            {
                try
                {
                    var map = contentManager.Load<TiledMap>(Path.Combine("Maps", mapName));

                    mapByName.Add(mapName, map);
                    return map;
                }
                catch (Exception) when (mapName != MapNotFoundName)
                {
                    return LoadMap(MapNotFoundName);
                }
            }

            return mapByName[mapName];
        }

        public MapData LoadMapData(string mapName)
        {
            if (!mapDataByName.ContainsKey(mapName))
            {
                try
                {
                    var input = System.IO.File.ReadAllLines(
                        Path.Combine(contentManager.RootDirectory + Path.Combine("/Maps/Data", mapName)) + ".txt");

                    MapData mapData = new MapData();
                    int i = 0;
                    while (i < input.Length)
                    {
                        if (input[i] == "[npc]")
                        {
                            i++;
                            var npc = new NpcData();
                            npc.Name = input[i++];
                            Enum.TryParse(input[i++], true, out npc.Direction);
                            int.TryParse(input[i++], out npc.Sprite);
                            int.TryParse(input[i++], out npc.XTilePosition);
                            int.TryParse(input[i++], out npc.YTilePosition);
                            npc.OriginalDirection = npc.Direction;
                            var pokemon = input[i++];
                            if (pokemon != "NULL")
                            {
                                var pokemonlist = pokemon.Split(",");
                                for (var j = 0; j < pokemonlist.Length; j+=2)
                                {
                                    npc.Party.Add(PokemonFactory.PokemonMaker(pokemonlist[j], int.Parse(pokemonlist[j+1])));
                                }
                            }
                            int.TryParse(input[i++], out npc.PartySize);
                            int.TryParse(input[i++], out npc.Badge);
                            // TODO speech
                            npc.Speech = input[i++].Split(',').Select(Int32.Parse).ToList();
                            bool.TryParse(input[i++], out npc.Healer);
                            bool.TryParse(input[i++], out npc.Box);
                            bool.TryParse(input[i++], out npc.Shop);
                            if (input[i++] == "[/npc]")
                            {
                                mapData.NpcList.Add(npc);
                            }
                        }
                        else if (input[i] == "[warp]")
                        {
                            i++;
                            var warp = new WarpData();
                            int.TryParse(input[i++], out warp.XTilePosition);
                            int.TryParse(input[i++], out warp.YTilePosition);
                            int.TryParse(input[i++], out warp.XWarpPosition);
                            int.TryParse(input[i++], out warp.YWarpPosition);
                            int.TryParse(input[i++], out warp.XMapId);
                            int.TryParse(input[i++], out warp.YMapId);
                            int.TryParse(input[i++], out warp.Badge);
                            if (input[i++] == "[/warp]")
                            {
                                mapData.WarpList.Add(warp);
                            }
                        }
                        else
                        {
                            i++;
                        }
                    }

                    mapDataByName.Add(mapName, mapData);
                    return mapData;
                }
                catch (Exception) when (mapName != MapDataNotFoundName)
                {
                    return LoadMapData(MapDataNotFoundName);
                }
            }

            return mapDataByName[mapName];
        }

        public string[] LoadMapSpeech(string mapName)
        {
            if (!mapSpeechByName.ContainsKey(mapName))
            {
                try
                {
                    var speechLines = System.IO.File.ReadAllLines(
                        Path.Combine(contentManager.RootDirectory + Path.Combine("/Maps/Speech", mapName)) + ".txt");
                    mapSpeechByName.Add(mapName, speechLines);
                    return speechLines;
                }
                catch (Exception) when (mapName != MapSpeechNotFoundName)
                {
                    return LoadMapSpeech(MapSpeechNotFoundName);
                }
            }

            return mapSpeechByName[mapName];
        }
    }
}