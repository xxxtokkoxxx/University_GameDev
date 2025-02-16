namespace Codebase.UI
{
    public interface IView
    {
        ViewType ViewType { get; }
        void Show(object payload = null);
        void Hide();
    }
}