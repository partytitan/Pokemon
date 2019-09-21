using System;
using System.Collections.Generic;
using System.Text;
using Client.Services.Content;

namespace Client.World
{
    interface ILoadContentComponent : IComponent
    {
        void LoadContent(IContentLoader contentLoader);
    }
}
