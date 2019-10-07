namespace Client.Services.Windows
{
    public interface IWindowQueuer
    {
        void QueueWindow(Window window);
        bool WindowActive { get; }
    }
}