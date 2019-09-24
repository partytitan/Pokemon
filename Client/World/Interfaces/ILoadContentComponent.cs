using Client.Services.Content;

namespace Client.World.Interfaces
{
    interface ILoadContentComponent : IComponent
    {
        void LoadContent(IContentLoader contentLoader);
    }
}
