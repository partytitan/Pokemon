using Client.Services.Content;
using Client.Services.Windows;
using GameLogic.Battles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Client.PokemonBattle.Phases
{
    internal interface IPhase
    {
        bool IsDone { get; }
        void LoadContent(IContentLoader contentLoader, IWindowQueuer windowQueuer, Battle battleData);
        void Update(GameTime gameTime);
        IPhase GetNextPhase();
        void Draw(SpriteBatch spriteBatch);
    }
}
