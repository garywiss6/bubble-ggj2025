using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Moonkey.UI.Behaviour;

namespace Moonkey.UI
{

    [RequireComponent(typeof(CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        [SerializeField] private bool isShow;
        [SerializeField] private RectTransform rt;
        [SerializeField] private CanvasGroup cg;

        public RectTransform Rt => rt;
        public CanvasGroup Cg => cg;

        [SerializeField,InlineButton("RefreshOriginalPos", "Refresh")] private Vector2 originalPos;
        public Vector2 OriginalPos => originalPos;

        [SerializeReference] public List<UIBehaviour> behaviours = new List<UIBehaviour>();

        public bool IsShow => isShow;

        void Start()
        {
            rt = (RectTransform)transform;
            cg = GetComponent<CanvasGroup>();
        }

        
        private void RefreshOriginalPos()
        {
            originalPos = rt.anchoredPosition;
        }

        public void Invert()
        {
            if (isShow)
                Hide();
            else
                Show();
        }

        public void InstantInvert()
        {
            if (isShow)
                HideInstant();
            else
                ShowInstant();
        }

        public void Show()
        {
            if (isShow)
                return;

            foreach (UIBehaviour behaviour in behaviours)
                behaviour.OnShow(this);

            isShow = true;
        }

        public void Hide()
        {
            if (!isShow)
                return;

            foreach (UIBehaviour behaviour in behaviours)
                behaviour.OnHide(this);

            isShow = false;
        }


        [Button("Show")]
        public void ShowInstant()
        {
            if (isShow)
                return;

            foreach (UIBehaviour behaviour in behaviours)
                behaviour.OnShowInstant(this);

            isShow = true;
        }

        [Button("Hide")]
        public void HideInstant()
        {
            if (!isShow)
                return;

            foreach (UIBehaviour behaviour in behaviours)
                behaviour.OnHideInstant(this);

            isShow = false;
        }
    }
}

