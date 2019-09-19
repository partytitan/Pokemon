using Client.Services.Content;
using Client.Services.Screens;
using Client.World;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Client.Screens
{
    class ScreenWorld : Screen
    {
        private Entity entity;
        private List<TileGraphic> tiles; //For test! 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ScreenWorld(IScreenLoader screenLoader) : base(screenLoader)
        {
            entity = new Entity("MyFirstEntity");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 19,
                Width = 15,
                TextureName = "NPC/main_character",
                XTilePosition = 2,
                YTilePosition = 2
            }, new Rectangle(0, 0, 16, 19)));
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard()));
            entity.AddComponent(new Animation(entity));
            tiles = TileGenerator.GenerateTiles();
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            entity.LoadContent(contentLoader);
            foreach (var tileGraphic in tiles)
            {
                tileGraphic.LoadContent(contentLoader);
            }
        }

        public override void Update(double gameTime)
        {
            entity.Update(gameTime);
            foreach (var tileGraphic in tiles)
            {
                tileGraphic.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tileGraphic in tiles)
            {
                tileGraphic.Draw(spriteBatch);
            }
            entity.Draw(spriteBatch);
        }
    }
}
