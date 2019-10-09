using Client.Data;
using Client.Inputs;
using Client.World;
using Client.World.Components;
using Client.World.Components.Animations;
using Client.World.Components.Movements;
using GameLogic.Data;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Client.Services.World.EventSwitches;

namespace Client.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<WorldObject> LoadEntities(IWorldData worldData, EventRunner eventRunner, EventSwitchHandler eventSwitchHandler, MainPlayer mainPlayer)
        {
            var entity = new WorldObject("mainPlayer", eventSwitchHandler);
            entity.AddComponent(
                    new Sprite(
                        entity,
                        new SpriteData
                        {
                            Color = Color.White,
                            Height = 20,
                            Width = 15,
                            TextureName = "NPC/main_character",
                            XTilePosition = worldData.MainPlayer.WarpData.XWarpPosition,
                            YTilePosition = worldData.MainPlayer.WarpData.YWarpPosition
                        },
                        worldData.MainPlayer.CurrentDirection, 41, 51
                    )
                );
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard(), worldData));
            entity.AddComponent(new Animation(entity));
            entity.AddComponent(new Collision(entity, worldData));
            entity.AddComponent(new EntityUpdateComponent(entity, eventRunner, mainPlayer.Input, eventSwitchHandler));

            return new List<WorldObject> { entity };
        }
    }
}