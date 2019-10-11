using Client.Services.Content;
using Client.Services.World;
using Client.World.Components;
using Client.World.Emotions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Events
{
    internal class EventEmotion : IEvent
    {
        private readonly WorldObject owner;
        private readonly IEmotion emotion;
        public bool IsDone { get; private set; }

        public EventEmotion(WorldObject owner, IEmotion emotion)
        {
            this.owner = owner;
            this.emotion = emotion;
        }

        public void Initialize(IWorldData worldData)
        {
            IsDone = false;
            if (owner == null)
            {
                IsDone = true;
            }
            else
            {
                var sprite = owner.GetComponent<Sprite>();
                emotion.PlayEmotion((int)sprite.TilePosition.X, (int)sprite.TilePosition.Y - 1);
            }
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            emotion.LoadContent(contentLoader);
        }

        public void Update(GameTime gameTime)
        {
            emotion.Update(gameTime);
            if (emotion.IsDone)
            {
                IsDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            emotion.Draw(spriteBatch);
        }
    }
}
