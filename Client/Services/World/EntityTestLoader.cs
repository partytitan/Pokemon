using Client.Data;
using Client.Inputs;
using Client.World;
using Client.World.Components;
using Client.World.Components.Animations;
using Client.World.Components.Movements;
using GameLogic.Data;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Client.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<WorldObject> LoadEntities(IWorldData worldData, WarpData warpData)
        {
            var entity = new WorldObject("player");
            entity.AddComponent(
                    new Sprite(
                        entity,
                        new SpriteData
                        {
                            Color = Color.White,
                            Height = 20,
                            Width = 15,
                            TextureName = "NPC/main_character",
                            XTilePosition = warpData.XWarpPosition,
                            YTilePosition = warpData.YWarpPosition
                        },
                        new Rectangle(0, 0, 41, 51)
                    )
                );
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard(), worldData));
            entity.AddComponent(new Animation(entity));
            entity.AddComponent(new Collision(entity, worldData));

            return new List<WorldObject> { entity };
        }
    }
}