using Client.Data;
using Client.Inputs;
using Client.World;
using Client.World.Components;
using Client.World.Components.Animations;
using Client.World.Components.Movements;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Screens;

namespace Client.Services.World
{
    internal class EntityTestLoader : IEntityLoader
    {
        public IList<Entity> LoadEntities(IComponentOwner owner, Camera camera, IList<ICollisionObject> collisionObjects)
        {
            var entity = new Entity(owner,"MyFirstEntity");
            entity.AddComponent(
                    new Sprite(
                        entity,
                        new SpriteData
                        {
                            Color = Color.White,
                            Height = 20,
                            Width = 15,
                            TextureName = "NPC/main_character",
                            XTilePosition = 10,
                            YTilePosition = 18
                        },
                        new Rectangle(0, 0, 41, 51)
                    )
                );
            entity.AddComponent(new MovementPlayer(entity, 1, new InputKeyboard(), camera));
            entity.AddComponent(new Animation(entity));
            entity.AddComponent(new Collision(entity, new ReadOnlyCollection<ICollisionObject>(collisionObjects)));
            return new List<Entity> { entity };
        }
    }
}