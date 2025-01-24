using System;

namespace Moonkey.UI.Element
{
    [Serializable]
    public abstract class UIElement
    {
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnDown();
        public abstract void OnUp();
    }
}
