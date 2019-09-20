using Client.Services.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.Screens;
using Microsoft.Xna.Framework;

namespace Client.World
{
    internal class Entity : Component, IComponentOwner
    {
        private readonly IList<Component> components;
        public string Id { get; }

        public Entity(IComponentOwner owner, string id) : base(owner)
        {
            components = new List<Component>();
            Id = id;
        }

        public void AddComponent(Component component)
        {
            if (component != null)
            {
                components.Add(component);
            }
        }

        public T GetComponent<T>() where T : Component
        {
            var component = components.FirstOrDefault(c => c.GetType() == typeof(T));
            return (T)component;
        }

        public override void LoadContent(IContentLoader contentLoader)
        {
            foreach (var component in components)
            {
                component.LoadContent(contentLoader);
            }
        }

        public override void Update(GameTime gameTime)
        {
            var index = 0;
            while (index < components.Count)
            {
                if (components[index].Killed)
                {
                    components.RemoveAt(index);
                }
                else
                {
                    components[index].Update(gameTime);
                    index++;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
            {
                component.Draw(spriteBatch);
            }
        }
    }
}
