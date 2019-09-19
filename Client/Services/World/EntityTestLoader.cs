using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.Inputs;
using Client.World;
using Client.World.Components;
using Client.World.Components.Animations;
using Client.World.Components.Movements;
using Microsoft.Xna.Framework;

namespace Client.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<Entity> LoadEntities(string mapName)
        {
            var entity = new Entity("MyFirstEntity");
            entity.AddComponent(new Sprite(entity, new SpriteData
            {
                Color = Color.White,
                Height = 20,
                Width = 15,
                TextureName = "NPC/main_character",
                XTilePosition = 0,
                YTilePosition = 0
            }, new Rectangle(0, 0, 16, 19)));
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard()));
            entity.AddComponent(new Animation(entity));
            return new List<Entity> { entity };
        }
    }

}
