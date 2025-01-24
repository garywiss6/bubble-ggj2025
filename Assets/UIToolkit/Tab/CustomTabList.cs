using System.Collections.Generic;
using UnityEngine;


namespace Moonkey.UI
{
    public class CustomTabList : MonoBehaviour
    {
        [SerializeField] private List<CustomTabButton> buttons = new List<CustomTabButton>();
        [SerializeField] private CustomTabButton currentButton;
        public CustomTabButton CurrentButton => currentButton;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            foreach (CustomTabButton CB in buttons)
                CB.onSelect = ForceCurrentButton;
            if (currentButton == null)
                return;
            ForceCurrentButton(currentButton);
        }

        public void AddButton(CustomTabButton btn)
        {
            buttons.Add(btn);
            btn.onSelect = ForceCurrentButton;
        }

        public void SetCurrentButton(CustomTabButton btn) => currentButton = btn;

        private void ForceCurrentButton(CustomTabButton button)
        {
            if (currentButton != null)
            {
                currentButton.IsSelected = false;
                currentButton.OnPointerExit(null);
            }
            currentButton = button;
            currentButton.IsSelected = true;
            currentButton.OnPointerEnter(null);
        }

        public void Activate()
        {
            foreach (CustomTabButton CB in buttons)
                CB.gameObject.SetActive(true);
        }
        public void Desactivate()
        {
            foreach (CustomTabButton CB in buttons)
                CB.gameObject.SetActive(false);
        }
    }
}
