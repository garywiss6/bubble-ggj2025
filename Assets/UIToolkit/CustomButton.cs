using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Moonkey.UI.Element;
using UnityEngine.Events;
using System;

namespace Moonkey.UI
{
    public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private bool interacable = true;

        [SerializeField] private UIView view;

        [SerializeField] private RectTransform rect;

        [SerializeField, SerializeReference] private List<UIElement> UIElements = new List<UIElement>();

        [SerializeField] private UnityEvent onClick;

        public event Action onClickDelegate;

        private bool isHover;

        private void Start()
        {
            rect = (RectTransform)transform;
        }

        public void Clear()
        {
            onClick = null;
            onClickDelegate = null;
        }

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
            if (!interacable)
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
            onClick?.Invoke();
            onClickDelegate?.Invoke();
        }
        #endregion
    }
}