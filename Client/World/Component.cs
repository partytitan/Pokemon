using Client.Services.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Client.Screens;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Client.World
{
    internal abstract class Component
    {
        protected IComponentOwner Owner;
        public bool Killed { get; protected set; }

        protected Component(IComponentOwner owner)
        {
            Owner = owner;
        }

        public virtual void LoadContent(IContentLoader contentLoader) { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
