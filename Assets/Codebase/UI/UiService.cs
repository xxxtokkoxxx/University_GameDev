using System.Collections.Generic;
using System.Linq;

namespace Codebase.UI
{
    public class UiService : IUiService
    {
        private List<IView> _views;

        public void SetViews(List<IView> views)
        {
            _views = views;
        }

        public void ShowScreen(ViewType viewType)
        {
            IView view = _views.First(a => a.ViewType == viewType);
            view.Show();
        }

        public void HideScreen(ViewType viewType)
        {
            IView view = _views.First(a => a.ViewType == viewType);
            view.Hide();
        }
    }
}