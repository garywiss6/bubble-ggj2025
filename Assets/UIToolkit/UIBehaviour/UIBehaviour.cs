using System;

namespace Moonkey.UI.Behaviour
{
    [Serializable]
    public abstract class UIBehaviour
    {
        public abstract void OnShow(UIView _view);
        public abstract void OnHide(UIView _view);
        public abstract void OnShowInstant(UIView _view);
        public abstract void OnHideInstant(UIView _view);
    }

}
