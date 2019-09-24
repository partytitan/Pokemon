using Client.Services.Content;

namespace Client.World.Interfaces
{
    internal interface ILoadContentComponent : IComponent
    {
        void LoadContent(IContentLoader contentLoader);
    }
}