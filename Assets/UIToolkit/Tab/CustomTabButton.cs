using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Moonkey.UI.Element;
using UnityEngine.Events;
using System;

namespace Moonkey.UI
{
    public class CustomTabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private bool interacable = true;

        [SerializeField] private UIView view;

        [SerializeField] private RectTransform rect;

        [SerializeField, SerializeReference] private List<UIElement> UIElements = new List<UIElement>();

        [SerializeField] private UnityEvent onClick;
        private event Action internalOnClick;
        public Action<CustomTabButton> onSelect;

        private bool isHover;
        private bool isSelected;
        public bool IsSelected 
        {
            get => isSelected; 
            set => isSelected = value;
        }

        private void Start()
        {
            rect = (RectTransform)transform;
        }

        public void AddEvent(Action action) => internalOnClick += action;
        public void RemoveEvent(Action action) => internalOnClick -= action;
        public void ClearEvent() => internalOnClick = null;

        #region BUTTON_INTERFACE
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interacable)
                return;

            UIElements.ForEach(x => x.OnEnter());

            if (view != null)
                view.Show();

            isHover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interacable || isSelected)
                return;

            UIElements.ForEach(x => x.OnExit());

            if (view != null)
                view.Hide();

            isHover = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!interacable)
                return;

            if (!isHover)
                OnPointerExit(eventData);
            else
                OnPointerEnter(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!interacable)
                return;

            UIElements.ForEach(x => x.OnDown());

            if (view != null)
                view.Hide();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!interacable)
                return;

            onClick.Invoke();
            internalOnClick?.Invoke();
            onSelect?.Invoke(this);
        }
        #endregion
    }
}