using System.Collections.Generic;

namespace Codebase.UI
{
    public interface IUiService
    {
        void SetViews(List<IView> views);
        IView ShowScreen(ViewType viewType);
        IView HideScreen(ViewType viewType);
    }
}