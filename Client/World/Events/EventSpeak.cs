using Client.Inputs;
using Client.Services.Content;
using Client.Services.Windows;
using Client.Services.Windows.Message;
using Client.Services.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.World.Events
{
    internal class EventSpeak : IEvent
    {
        private readonly IWindowQueuer windowQueuer;
        private readonly InputKeyboard inputKeyboard;
        private readonly IWorldData worldData;
        private readonly string lines;

        public bool IsDone { get; private set; }
        public EventSpeak(string lines, IWindowQueuer windowQueuer, InputKeyboard inputKeyboard, IWorldData worldData)
        {
            this.lines = lines;
            this.windowQueuer = windowQueuer;
            this.inputKeyboard = inputKeyboard;
            this.worldData = worldData;
        }

        public void Initialize(IWorldData worldData)
        {
            worldData.MainPlayer.CanMove = false;
            worldData.MainPlayer.IsInteracting = true;

            var message = new WindowMessage(new Vector2(25, 180), 350, 50, lines, inputKeyboard);
            message.OnClose += Message_OnClose;
            windowQueuer.QueueWindow(message);
            IsDone = true;
        }

        private void Message_OnClose(object sender, System.EventArgs e)
        {
            worldData.MainPlayer.CanMove = true;
            worldData.MainPlayer.IsInteracting = false;
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