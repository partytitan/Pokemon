using System;
using System.Collections.Generic;
using System.Text;
using Client.Data;
using Client.Services.Content;
using Client.Services.World.EventSwitches;
using Client.World.Components;
using Client.World.Components.Animations;
using Client.World.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Emotions
{
    internal class EmotionTrainer : IEmotion
    {
        private const int EmotionTime = 1000;
        private readonly WorldObject worldObject;
        private double counter;
        private float extraY;
        public bool IsDone { get; private set; }

        public EmotionTrainer(IEventSwitchPriority eventSwitchPriority)
        {
            worldObject = new WorldObject("emotion", eventSwitchPriority);
            worldObject.AddComponent(new Sprite(worldObject, new SpriteData
            {
                Color = Color.White,
                Height = 16,
                Width = 16,
                TextureName = "Emotions/trainer_b"
            }));
            worldObject.AddComponent(new Animation(worldObject));
        }

        public void PlayEmotion(int xTilePosition, int yTilePosition)
        {
            IsDone = false;
            counter = 0;
            extraY = -5;
            worldObject.GetComponent<Sprite>().ResetPositionOffset();
            worldObject.GetComponent<Sprite>().UpdateTilePosition(xTilePosition, yTilePosition);
            worldObject.GetComponent<Animation>().PlayAnimation(new AnimationEmotion());
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            worldObject.GetComponents<ILoadContentComponent>().ForEach(c => c.LoadContent(contentLoader));
        }

        public void Update(GameTime gameTime)
        {
            worldObject.GetComponents<IUpdateComponent>().ForEach(c => c.Update(gameTime));
            counter += gameTime.ElapsedGameTime.Milliseconds;
            if (counter > EmotionTime)
            {
                IsDone = true;
            }
            //For the extra bounce
            if (extraY < 6)
            {
                worldObject.GetComponent<Sprite>().IncreasePositionOffset(0, extraY);
                extraY++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            worldObject.GetComponents<IDrawComponent>().ForEach(c => c.Draw(spriteBatch));
        }
    }
}
