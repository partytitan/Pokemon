using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;
using Client.Services.Screens;
using Client.Services.World;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Events
{
    class EventBattle : IEvent
    {
        private readonly TrainerSide trainerSide;
        public bool IsDone { get; }

        public EventBattle(TrainerSide trainerSide)
        {
            this.trainerSide = trainerSide;
        }
        public void Initialize(IWorldData worldData)
        {
            worldData.StartBattle(trainerSide, new TrainerPokemonActor());
        }

        public void LoadContent(IContentLoader contentLoader)
        {
            
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
