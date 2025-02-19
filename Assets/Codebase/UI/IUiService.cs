using System.Collections.Generic;

namespace Codebase.UI
{
    public interface IUiService
    {
        void SetViews(List<IView> views);
        void ShowScreen(ViewType viewType);
        void HideScreen(ViewType viewType);
    }
}