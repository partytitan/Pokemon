using Client.Inputs;
using Client.Services.Content;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using Client.Services.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Events
{
    internal class EventSpeek : IEvent
    {
        private readonly IWindowQueuer windowQueuer;
        private readonly InputKeyboard inputKeyboard;
        private readonly string lines;

        public bool IsDone { get; private set; }
        public EventSpeek(string lines, IWindowQueuer windowQueuer, InputKeyboard inputKeyboard)
        {
            this.lines = lines;
            this.windowQueuer = windowQueuer;
            this.inputKeyboard = inputKeyboard;
        }

        public void Initialize(IWorldData worldData)
        {
            windowQueuer.QueueWindow(new WindowMessage(new Vector2(25, 180), 350, 50, lines, inputKeyboard));
            IsDone = true;
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