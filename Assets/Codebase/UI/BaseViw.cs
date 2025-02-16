using UnityEngine;

namespace Codebase.UI
{
    public abstract class BaseViw : MonoBehaviour, IView
    {
        public abstract ViewType ViewType { get; }

        public virtual void Show(object payload = null)
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}